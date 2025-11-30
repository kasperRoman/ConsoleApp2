using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClienDemo2
{
    public class WeatherResponse
    {
        public MainInfo? Main { get; set; }
        public List<WeatherInfo>? Weather { get; set; }
        public string? Name { get; set; }
    }

    public class MainInfo
    {
        public float Temp { get; set; }
    }

    public class WeatherInfo
    {
        public string? Description { get; set; }
    }
}
