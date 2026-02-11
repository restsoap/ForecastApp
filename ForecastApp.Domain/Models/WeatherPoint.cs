using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.Domain.Models
{
    public class WeatherPoint
    {
        public DateTime Time { get; set; }
        public double Temperature { get; set; }
    }

    public class WeatherReport
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public List<WeatherPoint> HourlyForecast { get; set; } = new();
    }
}
