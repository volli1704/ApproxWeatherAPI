using System;

namespace ApproxWeatherAPI.Dtos
{
    public record WeatherForecastDto
    {
        public uint timestamp { get; init; }
        public float temperature { get; init; }
    }
}