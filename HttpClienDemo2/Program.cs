using HttpClienDemo2;
using HttpClientDemo2;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

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
            if (string.IsNullOrWhiteSpace(apiKey))
            {
                Console.WriteLine("API ключ не знайдено.");
                return;
            }

            Console.Write("Введіть назву міста: ");
            string? city = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(city))
            {
                Console.WriteLine("Місто не введено.");
                return;
            }

            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={apiKey}&units=metric&lang=ua";

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

                Console.WriteLine($"Місто: {weather.Name}");
                Console.WriteLine($"Температура: {weather.Main.Temp}°C");
                Console.WriteLine($"Погода: {weather.Weather[0].Description}");
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