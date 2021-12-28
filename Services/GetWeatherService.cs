using System;
using System.Collections.Generic;
using System.Collections;
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

        public async Task<IEnumerable<WeatherForecastDto>> GetForecastAsync()
        {
            var profiles = context.Profiles;
            var tasks = new List<Task<List<WeatherForecastDto>>>();
            var result = new List<List<WeatherForecastDto>>();

            foreach (Profile profile in profiles)
            {
                var prof = profile;
                tasks.Add(getForecastForProfileAsync(prof));
            }

            foreach (var task in await Task.WhenAll(tasks))
            {
                result.Add(task);
            }

            var mergedWeatherData = new Dictionary<uint, List<float>>();
            var unionWeatherData = result.SelectMany(x => x).ToList();
            foreach (var r in unionWeatherData)
            {
                if (!mergedWeatherData.ContainsKey(r.timestamp))
                {
                    mergedWeatherData[r.timestamp] = new List<float>();
                }

                mergedWeatherData[r.timestamp].Add(r.temperature);
            }

            var rz = mergedWeatherData.Select(e => new { ts = e.Key, t = e.Value })
                .Select(d => new WeatherForecastDto() { timestamp = d.ts, temperature = d.t.Average() })
                .ToList();

            return rz;
        }

        protected async Task<List<WeatherForecastDto>> getForecastForProfileAsync(Profile profile)
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