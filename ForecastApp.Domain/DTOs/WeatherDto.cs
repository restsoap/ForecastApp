using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ForecastApp.Domain.DTOs
{
    // El objeto principal que envuelve todo
    public record WeatherResponseDto(
        [property: JsonPropertyName("latitude")] double Latitude,
        [property: JsonPropertyName("longitude")] double Longitude,
        [property: JsonPropertyName("hourly")] HourlyDataDto Hourly
    );

    // Los datos internos (Arrays paralelos)
    public record HourlyDataDto(
        [property: JsonPropertyName("time")] List<string> Time,
        [property: JsonPropertyName("temperature_2m")] List<double> Temperature2m
    );
}
