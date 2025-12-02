using Microsoft.Extensions.Logging;

namespace HttpClientDemo2
{
    public class WeatherApp
    {
        private readonly IWeatherService _service;
        private readonly ILogger<WeatherApp> _logger;

        public WeatherApp(IWeatherService service, ILogger<WeatherApp> logger)
        {
            _service = service;
            _logger = logger;
        }

        public async Task RunAsync()
        {
            Console.Write("Введіть назву міста: ");
            string? city = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(city))
            {
                _logger.LogWarning("Місто не введено.");
                return;
            }

            var weather = await _service.GetWeatherAsync(city);

            if (weather == null)
            {
                _logger.LogError("❌ Не вдалося отримати погоду.");
                return;
            }

            _logger.LogInformation($"🌍 Місто: {weather.Name}, Країна: {weather.Country}");
            _logger.LogInformation($"🌡 Температура: {weather.Main.Temp}°C");
            _logger.LogInformation($"💧 Вологість: {weather.Main.Humidity}%");
            _logger.LogInformation($"🌬 Вітер: {weather.Wind?.Speed} м/с");
            _logger.LogInformation($"☁ Погода: {weather.Weather[0].Description}");
        }
    }
}
