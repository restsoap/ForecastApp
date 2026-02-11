# 🌤️ ForecastApp - Weather API

Una API RESTful robusta y moderna construida con **.NET 9**, diseñada para proporcionar pronósticos meteorológicos precisos consumiendo la API de [Open-Meteo](https://open-meteo.com/).

Este proyecto implementa una **Arquitectura N-Capas (Clean Architecture)** para asegurar la escalabilidad, mantenibilidad y la separación de responsabilidades.

![.NET](https://img.shields.io/badge/.NET-9.0-512BD4?style=flat&logo=dotnet)
![Architecture](https://img.shields.io/badge/Architecture-N--Layer-blue)
![Status](https://img.shields.io/badge/Status-Active-success)

## 🚀 Características

- **Consumo de API Externa:** Integración eficiente con Open-Meteo usando `HttpClient`.
- **Transformación de Datos:** Mapeo de DTOs "crudos" a Modelos de Dominio limpios y fáciles de consumir.
- **Inyección de Dependencias:** Configuración nativa de .NET para servicios y clientes HTTP.
- **Documentación:** Integración con **Swagger UI** para probar endpoints visualmente.
- **CORS Configurado:** Listo para integrarse con Frontends (Angular/React).
- **Tipado Fuerte:** Uso de `Records` y `DTOs` para inmutabilidad y rendimiento.

## 🏗️ Arquitectura del Proyecto

El proyecto está dividido en tres capas principales para desacoplar la lógica:

| Capa | Responsabilidad |
| :--- | :--- |
| **📂 ForecastApp.Domain** | El núcleo. Contiene las **Interfaces** (`IWeatherService`) y los **Modelos** de negocio (`WeatherPoint`, `WeatherReport`). No tiene dependencias externas. |
| **📂 ForecastApp.Infrastructure** | La implementación. Contiene la lógica para llamar a la API externa (`OpenMeteoService`) y transformar los datos. |
| **📂 ForecastApp.Api** | La entrada. Contiene los **Controllers**, configuración de DI (`Program.cs`) y Swagger. |

## 🛠️ Tecnologías Utilizadas

* [ASP.NET Core 9 Web API](https://dotnet.microsoft.com/)
* [C# 13](https://learn.microsoft.com/en-us/dotnet/csharp/)
* [Swashbuckle (Swagger)](https://github.com/domaindrivendev/Swashbuckle.AspNetCore) - Documentación de API.
* [Open-Meteo API](https://open-meteo.com/) - Fuente de datos meteorológicos gratuita.

## ⚙️ Instalación y Ejecución

1.  **Clonar el repositorio:**
    ```bash
    git clone [https://github.com/tu-usuario/ForecastApp.git](https://github.com/tu-usuario/ForecastApp.git)
    cd ForecastApp
    ```

2.  **Restaurar paquetes:**
    ```bash
    dotnet restore
    ```

3.  **Ejecutar la API:**
    ```bash
    dotnet run --project ForecastApp.Api
    ```

4.  **Ver documentación:**
    Abre tu navegador en `https://localhost:{PUERTO}/swagger` para ver la interfaz de prueba.

## 📡 Uso de la API

### Obtener Pronóstico
Devuelve el clima transformado y limpio para una ubicación específica.

**Endpoint:**
`GET /api/weather`

**Parámetros:**
* `latitude`: (double) Latitud de la ubicación.
* `longitude`: (double) Longitud de la ubicación.

**Ejemplo de Solicitud:**
```http
GET https://localhost:7219/api/weather?latitude=4.75&longitude=-74.03
