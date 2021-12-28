using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApproxWeatherAPI.Dtos;

namespace ApproxWeatherAPI.Services
{
    public interface IGetWeatherService
    {
        public Task<IEnumerable<WeatherForecastDto>> GetForecastAsync();
    }
}