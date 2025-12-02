using HttpClientDemo2;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Text.Json;

namespace HttpClientDemo2
{
    public interface IWeatherService
    {
        Task<WeatherResponse?> GetWeatherAsync(string city);
    }

    public class WeatherService : IWeatherService
    {
        private readonly HttpClient _client;
        private readonly ILogger<WeatherService> _logger;
        private readonly OpenWeatherOptions _options;

        public WeatherService(
            HttpClient client,
            IOptions<OpenWeatherOptions> options,
            ILogger<WeatherService> logger)
        {
            _client = client;
            _logger = logger;
            _options = options.Value;
        }

        public async Task<WeatherResponse?> GetWeatherAsync(string city)
        {
            string cityEscaped = Uri.EscapeDataString(city);

            // URL будується автоматично, бо client.BaseAddress вже встановлено
            var uriBuilder = new UriBuilder(_client.BaseAddress!);
            uriBuilder.Query =
                $"q={cityEscaped}&appid={_options.ApiKey}&units=metric&lang=ua";

            string url = uriBuilder.ToString();

            _logger.LogInformation($"🔍 Виконую запит: {url}");

            using HttpResponseMessage response = await _client.GetAsync(url);

            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    _logger.LogError("❌ Невірний API ключ (401)");
                    return null;

                case HttpStatusCode.Forbidden:
                    _logger.LogError("❌ API ключ заблоковано (403)");
                    return null;

                case HttpStatusCode.NotFound:
                    _logger.LogWarning("⚠️ Місто не знайдено (404)");
                    return null;

                default:
                    if (!response.IsSuccessStatusCode)
                    {
                        _logger.LogError($"❌ Помилка: {response.StatusCode}");
                        return null;
                    }
                    break;
            }

            string json = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<WeatherResponse>(json,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}