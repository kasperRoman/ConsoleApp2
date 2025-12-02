using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace HttpClientDemo2
{
    public class WeatherResponse
    {
        [JsonPropertyName("name")]
        public string? Name { get; set; }

        [JsonPropertyName("sys")]
        public Sys? Sys { get; set; }

        // Зручна властивість, щоб не писати weather.Sys.Country всюди
        [JsonIgnore]
        public string? Country => Sys?.Country;

        [JsonPropertyName("main")]
        public MainInfo? Main { get; set; }

        [JsonPropertyName("wind")]
        public Wind? Wind { get; set; }

        [JsonPropertyName("weather")]
        public List<WeatherInfo>? Weather { get; set; }
    }

    public class Sys
    {
        [JsonPropertyName("country")]
        public string? Country { get; set; }
    }

    public class MainInfo
    {
        [JsonPropertyName("temp")]
        public double Temp { get; set; }

        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }
    }

    public class Wind
    {
        [JsonPropertyName("speed")]
        public double Speed { get; set; }
    }

    public class WeatherInfo
    {
        [JsonPropertyName("description")]
        public string? Description { get; set; }
    }
}