using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using HttpClientDemo2;

namespace HttpClientDemo2
{
    internal class Program
    {
        static readonly HttpClient client = new HttpClient();

        static async Task Main(string[] args)
        {
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            string? apiKey = config["OpenWeatherMap:ApiKey"];
            string? baseUrl = config["OpenWeatherMap:BaseUrl"];
            string? timeoutStr = config["OpenWeatherMap:TimeoutSeconds"];

            if (string.IsNullOrWhiteSpace(apiKey))
            {
                Console.WriteLine("API ключ не знайдено.");
                return;
            }

            if (!int.TryParse(timeoutStr, out int timeoutSeconds))
            {
                timeoutSeconds = 10; 
            }

            client.Timeout = TimeSpan.FromSeconds(timeoutSeconds);

            Console.Write("Введіть назву міста: ");
            string? city = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(city))
            {
                Console.WriteLine("Місто не введено.");
                return;
            }

            string url = $"{baseUrl}?q={city}&appid={apiKey}&units=metric&lang=ua";

            try
            {
                HttpResponseMessage response = await client.GetAsync(url);

                if (response.StatusCode == System.Net.HttpStatusCode.NotFound)
                {
                    Console.WriteLine("Місто не знайдено. Перевірте написання.");
                    return;
                }

                response.EnsureSuccessStatusCode();

                string json = await response.Content.ReadAsStringAsync();

                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                WeatherResponse? weather = JsonSerializer.Deserialize<WeatherResponse>(json, options);

                if (weather == null || weather.Main == null || weather.Weather == null || weather.Weather.Count == 0)
                {
                    Console.WriteLine("Не вдалося обробити відповідь.");
                    return;
                }

                Console.WriteLine($"🌍 Місто: {weather.Name}, Країна: {weather.Country}");
                Console.WriteLine($"🌡️ Температура: {weather.Main.Temp}°C");
                Console.WriteLine($"💧 Вологість: {weather.Main.Humidity}%");
                Console.WriteLine($"🌬️ Вітер: {weather.Wind?.Speed} м/с");
                Console.WriteLine($"☁️ Погода: {weather.Weather[0].Description}");
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine("Помилка запиту. Перевірте ключ або підключення до інтернету.");
                Console.Error.WriteLine($"[DEV] {ex.Message}");
            }
            catch (JsonException jex)
            {
                Console.WriteLine("Помилка при обробці JSON.");
                Console.Error.WriteLine($"[DEV] {jex.Message}");
            }
        }
    }
}