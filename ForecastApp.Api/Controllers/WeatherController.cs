using ForecastApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ForecastApp.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IWeatherService _weatherService;

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    // GET: api/weather?latitude=4.75&longitude=-74.03
    [HttpGet]
    public async Task<IActionResult> GetForecast([FromQuery] double latitude, [FromQuery] double longitude)
    {
        // Validamos que las coordenadas sean lógicas
        if (latitude < -90 || latitude > 90)
            return BadRequest("La latitud debe estar entre -90 y 90.");

        if (longitude < -180 || longitude > 180)
            return BadRequest("La longitud debe estar entre -180 y 180.");

        try
        {
            var report = await _weatherService.GetWeatherAsync(latitude, longitude);

            if (report is null)
                return NotFound("No se pudieron obtener datos del clima para esa ubicación.");

            // 3. Devolvemos el JSON limpio (Status 200 OK)
            return Ok(report);
        }
        catch (Exception ex)
        {
            // retorno de errores
            return StatusCode(500, $"Error interno del servidor: {ex.Message}");
        }
    }
}