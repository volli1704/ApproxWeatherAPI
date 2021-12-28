using System;

namespace ApproxWeatherAPI.Dtos
{
    public record WeatherForecastDto
    {
        public DateTime timestamp { get; init; }
        public float temperature { get; init; }
    }
}