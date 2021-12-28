using System;
using System.Collections.Generic;
using System.Linq;
using ApproxWeatherAPI.Entities;
using Newtonsoft.Json.Linq;

namespace ApproxWeatherAPI.Dtos
{
    public class WeatherForecastFactory
    {
        public static IEnumerable<WeatherForecastDto> DtoListFromJson(JObject response, Profile profile)
        {
            var schemaJson = JObject.Parse(profile.Schema);
            var datetimePath = ((string)schemaJson["datetime"]);
            var temperaturePath = ((string)schemaJson["temperature"]);

            var datetimeValues = schemaJson.SelectTokens(datetimePath).ToList();
            var temperatureValues = schemaJson.SelectTokens(temperaturePath).ToList();
            var combined = datetimeValues.Zip(temperatureValues, (d, t) => new WeatherForecastDto()
            {
                timestamp = (DateTime)d,
                temperature = (float)t
            });

            return combined;
        }
    }
}