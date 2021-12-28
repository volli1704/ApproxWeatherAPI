using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using ApproxWeatherAPI.Dtos;
using ApproxWeatherAPI.Entities;
using Newtonsoft.Json.Linq;

namespace ApproxWeatherAPI.Services
{
    public class GetWeatherService : IGetWeatherService
    {
        private readonly WeatherAPIContext context;

        public GetWeatherService(WeatherAPIContext context)
        {
            this.context = context;
        }

        public List<WeatherForecastDto> GetForecastAsync()
        {
            var profiles = context.Profiles;


            var weatherCollectors = (from profile in profiles.ToList()
                                     select getForecastForProfileAsync(profile)).ToList();



            return new List<WeatherForecastDto>();
        }

        protected async Task<IEnumerable<WeatherForecastDto>> getForecastForProfileAsync(Profile profile)
        {
            var HttpResults = new List<WeatherForecastDto>();

            using var client = new HttpClient();
            var headers = JObject.Parse(profile.Headers);
            foreach (var header in headers)
            {
                client.DefaultRequestHeaders.Add(header.Key, header.Value.ToString());
            }
            var response = await client.SendAsync(new HttpRequestMessage(HttpMethod.Get, profile.URL));
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();

            var responseJson = JObject.Parse(responseBody);

            return WeatherForecastFactory.DtoListFromJson(responseJson, profile);
        }
    }
}