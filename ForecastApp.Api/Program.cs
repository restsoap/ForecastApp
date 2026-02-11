using ForecastApp.Domain.Interfaces;
using ForecastApp.Infraestructure.Services;

namespace ForecastApp.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddHttpClient<IWeatherService, OpenMeteoService>(client =>
            {
                // Configuramos la URL base aquí para no repetirla en el código
                client.BaseAddress = new Uri("https://api.open-meteo.com/v1/");

                // Open-Meteo pide amablemente que nos identifiquemos
                client.DefaultRequestHeaders.Add("User-Agent", "ForecastApp-NetCore9");
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("PoliticaAngular", app =>
                {
                    app.WithOrigins("http://localhost:4200")
                       .AllowAnyHeader()
                       .AllowAnyMethod();
                });
            });

            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
            }

            app.UseCors("PoliticaAngular");

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
