using ForecastApp.Domain.DTOs;
using ForecastApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForecastApp.Domain.Interfaces
{
    public interface IWeatherService
    {
        Task<WeatherReport?> GetWeatherAsync(double latitude, double longitude);
    }
}
