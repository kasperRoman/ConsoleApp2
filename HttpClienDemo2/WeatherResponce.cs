namespace HttpClientDemo2
{
    public class WeatherResponse
    {
        public MainInfo? Main { get; set; }
        public List<WeatherInfo>? Weather { get; set; }
        public WindInfo? Wind { get; set; }
        public string? Name { get; set; }
        public string? Country => Sys?.Country;
        public SysInfo? Sys { get; set; }
    }

    public class MainInfo
    {
        public float Temp { get; set; }
        public int Humidity { get; set; }
    }

    public class WeatherInfo
    {
        public string? Description { get; set; }
    }

    public class WindInfo
    {
        public float Speed { get; set; }
    }

    public class SysInfo
    {
        public string? Country { get; set; }
    }
}