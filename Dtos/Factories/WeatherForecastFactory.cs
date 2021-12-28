using System;
using System.Collections.Generic;
using System.Linq;
using ApproxWeatherAPI.Entities;
using Newtonsoft.Json.Linq;

namespace ApproxWeatherAPI.Dtos
{
    public class WeatherForecastFactory
    {
        public static List<WeatherForecastDto> DtoListFromJson(JObject response, Profile profile)
        {
            var schemaJson = JObject.Parse(profile.Schema);
            var datetimePath = (string)schemaJson["datetime"];
            var temperaturePath = (string)schemaJson["temperature"];
            var temperatureType = (string)schemaJson["t-metrica"];

            var datetimeValues = response.SelectTokens(datetimePath).ToList();
            var temperatureValues = response.SelectTokens(temperaturePath).ToList();

            var combined = datetimeValues.Zip(temperatureValues, (d, t) => new WeatherForecastDto()
            {
                timestamp = (uint)d,
                temperature = normalizeTemperature(temperatureType, (float)t)
            });

            return combined.ToList();
        }

        protected static float normalizeTemperature(string temperatureType, float temp)
        {
            temperatureType = temperatureType.ToLower();
            return temperatureType switch
            {
                "f" => (temp - 32) * 5 / 9,
                "k" => temp - 273.15F,
                _ => temp
            };
        }
    }
}