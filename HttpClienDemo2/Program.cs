using System;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace HttpClientDemo2
{
    internal class Program
    {
        // Загальний HttpClient — можна залишити, але у майбутньому поміняємо на IHttpClientFactory
        static readonly HttpClient client = new HttpClient();
        static ILogger<Program>? logger;

        static async Task Main(string[] args)
        {
            // --- Конфігурація ---
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // --- Логер ---
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
            });
            logger = loggerFactory.CreateLogger<Program>();

            string? apiKey = config["OpenWeatherMap:ApiKey"];
            string? baseUrl = config["OpenWeatherMap:BaseUrl"];
            string? timeoutStr = config["OpenWeatherMap:TimeoutSeconds"];

            if (string.IsNullOrWhiteSpace(apiKey) || string.IsNullOrWhiteSpace(baseUrl))
            {
                logger.LogError("❌ API ключ або BaseUrl не знайдено.");
                return;
            }

            if (!int.TryParse(timeoutStr, out int timeoutSeconds))
            {
                timeoutSeconds = 10;
                logger.LogWarning("⚠️ TimeoutSeconds некоректний, використано значення за замовчуванням: 10 секунд.");
            }

            client.Timeout = TimeSpan.FromSeconds(timeoutSeconds);

            // --- Ввід міста ---
            Console.Write("Введіть назву міста: ");
            string? cityInput = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(cityInput))
            {
                logger.LogWarning("⚠️ Місто не введено.");
                return;
            }

            // --- Крок 1: ескейпим введення (щоб безпечно вставити у query) ---
            string cityEscaped = Uri.EscapeDataString(cityInput.Trim());

            // --- Крок 1: будуємо URL без ручного конкатенування ---
            // Якщо baseUrl вже містить query — краще парсити, але зазвичай це базовий ендпойнт без query
            var uriBuilder = new UriBuilder(baseUrl);
            
            var query = $"q={cityEscaped}&appid={Uri.EscapeDataString(apiKey)}&units=metric&lang=ua";
            uriBuilder.Query = query;
            string url = uriBuilder.Uri.ToString();

            logger.LogInformation($"🔍 Запит погоди: {url}");

            try
            {
                // Використовуємо using — щоб явно звільнити HttpResponseMessage після читання
                using HttpResponseMessage response = await client.GetAsync(url);

                // --- Повний контроль над статусами (як у тебе було) ---
                switch (response.StatusCode)
                {
                    case HttpStatusCode.Unauthorized:
                        logger.LogError("❌ API ключ недійсний (401 Unauthorized).");
                        return;

                    case HttpStatusCode.Forbidden:
                        logger.LogError("❌ API ключ заблокований (403 Forbidden).");
                        return;

                    case HttpStatusCode.NotFound:
                        logger.LogWarning("⚠️ Місто не знайдено. Перевірте написання.");
                        return;

                    case HttpStatusCode.InternalServerError:
                        logger.LogError("❌ Помилка сервера (500 Internal Server Error).");
                        return;

                    default:
                        if (!response.IsSuccessStatusCode)
                        {
                            logger.LogError($"❌ Невдалий запит. Статус: {response.StatusCode}");
                            return;
                        }
                        break;
                }

                // Читаємо тіло і десеріалізуємо
                string json = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                WeatherResponse? weather = JsonSerializer.Deserialize<WeatherResponse>(json, options);

                if (weather == null || weather.Main == null || weather.Weather == null || weather.Weather.Count == 0)
                {
                    logger.LogError("❌ Не вдалося обробити відповідь.");
                    return;
                }

                logger.LogInformation($"🌍 Місто: {weather.Name}, Країна: {weather.Country}");
                logger.LogInformation($"🌡️ Температура: {weather.Main.Temp}°C");
                logger.LogInformation($"💧 Вологість: {weather.Main.Humidity}%");
                logger.LogInformation($"🌬️ Вітер: {weather.Wind?.Speed} м/с");
                logger.LogInformation($"☁️ Погода: {weather.Weather[0].Description}");
            }
            catch (HttpRequestException ex)
            {
                // HttpRequestException трапляється при проблемах мережі або після EnsureSuccessStatusCode()
                logger.LogError(ex, "❌ Помилка запиту. Перевірте ключ або підключення до інтернету.");
            }
            catch (JsonException jex)
            {
                // JsonException — помилка десеріалізації
                logger.LogError(jex, "❌ Помилка при обробці JSON.");
            }
        }
    }
}




