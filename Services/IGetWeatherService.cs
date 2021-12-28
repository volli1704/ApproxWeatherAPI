using System.Collections.Generic;
using ApproxWeatherAPI.Dtos;

namespace ApproxWeatherAPI.Services
{
    public interface IGetWeatherService
    {
        public List<WeatherForecastDto> GetForecastAsync();
    }
}