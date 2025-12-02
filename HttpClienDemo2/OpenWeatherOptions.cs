using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HttpClientDemo2
{
    public class OpenWeatherOptions
    {
        public string? ApiKey { get; set; }
        public string? BaseUrl { get; set; }
        public int TimeoutSeconds { get; set; }
    }
}
