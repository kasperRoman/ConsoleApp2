using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Configuration;
using HttpClientDemo2;

internal class Program
{
    static async Task Main(string[] args)
    {
        // Створюємо хост (DI контейнер + логування + конфігурація)
        using IHost host = Host.CreateDefaultBuilder(args)//автоматично додає стандартні провайдери конфігурації (appsettings.json, env vars, command line), логування (консоль і ін.), і т.д.
            .ConfigureAppConfiguration(config =>
            {
                config.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            })
            .ConfigureServices((context, services) =>
            {
                // Біндимо конфігурацію у POCO клас
                services.Configure<OpenWeatherOptions>(
                    context.Configuration.GetSection("OpenWeatherMap"));

                // Реєструємо HttpClient з базовими налаштуваннями
                services.AddHttpClient<IWeatherService, WeatherService>(client =>
                {
                    string? baseUrl = context.Configuration["OpenWeatherMap:BaseUrl"];
                    if (baseUrl != null)
                        client.BaseAddress = new Uri(baseUrl);

                    if (int.TryParse(context.Configuration["OpenWeatherMap:TimeoutSeconds"], out int t))
                        client.Timeout = TimeSpan.FromSeconds(t);
                });

                // Запускаємо WeatherApp як сервіс
                services.AddTransient<WeatherApp>();
            })
            .Build();

        // Запускаємо основну логіку
        await host.Services.GetRequiredService<WeatherApp>().RunAsync();
    }
}



