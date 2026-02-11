using System.Globalization;
using System.Net.Http.Json;
using ForecastApp.Domain.DTOs;
using ForecastApp.Domain.Interfaces;
using ForecastApp.Domain.Models;

namespace ForecastApp.Infraestructure.Services
{
    public class OpenMeteoService : IWeatherService
    {
        private readonly HttpClient _httpClient;

        // Inyectamos el HttpClient configurado
        public OpenMeteoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<WeatherReport?> GetWeatherAsync(double latitude, double longitude)
        {
            var lat = latitude.ToString(CultureInfo.InvariantCulture);
            var lon = longitude.ToString(CultureInfo.InvariantCulture);
            var url = $"forecast?latitude={lat}&longitude={lon}&hourly=temperature_2m";

            try
            {
                // Obtener el DTO Crudo (El JSON de Open-Meteo)
                var responseDto = await _httpClient.GetFromJsonAsync<WeatherResponseDto>(url);

                if (responseDto is null) return null;

                // MAPEO: Convertir DTO -> Domain Model
                var report = new WeatherReport
                {
                    Latitude = responseDto.Latitude,
                    Longitude = responseDto.Longitude,
                    HourlyForecast = new List<WeatherPoint>()
                };

                // Recorremos las listas paralelas del DTO
                for (int i = 0; i < responseDto.Hourly.Time.Count; i++)
                {
                    // Solo añadimos si hay dato de temperatura correspondiente
                    if (i < responseDto.Hourly.Temperature2m.Count)
                    {
                        report.HourlyForecast.Add(new WeatherPoint
                        {
                            // Convertimos el string de fecha a DateTime
                            Time = DateTime.Parse(responseDto.Hourly.Time[i]),
                            Temperature = responseDto.Hourly.Temperature2m[i]
                        });
                    }
                }

                return report;
            }
            catch (Exception ex)
            {
                // loggin para error
                Console.WriteLine($"Error obteniendo clima: {ex.Message}");
                return null;
            }
        }
    }
}
