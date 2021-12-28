using System;
using Microsoft.EntityFrameworkCore;

namespace ApproxWeatherAPI.Entities
{
    public partial class WeatherAPIContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(
                new Profile[]
                {
                new Profile {
                    Id = 1,

                    Name="weatherbit",

                    Schema = "{\"datetime\": \"data:<items>:timestamp_utc\",\"temperature\": \"data:<items>:temp\",\"t-metrica\":\"f\"}",

                    URL = "https://weatherbit-v1-mashape.p.rapidapi.com/forecast/daily?lat=50.9216&lon=-34.80029",

                    Headers = "{\"X-Rapidapi-Key\": \"5dcf0e8ad4mshc461e39c1a88700p1ed940jsn25b9db5489fb\"}",

                    Limit=3000,

                    DateCreated=DateTime.UtcNow,
                },
                new Profile {
                    Id = 2,

                    Name="visual-crossing",

                    Schema="{\"datetime\":\"$.data..datetime\",\"temperature\":\"$.data..temp\",\"t-metrica\":\"c\"}",

                    URL = "https://visual-crossing-weather.p.rapidapi.com/forecast?aggregateHours=24&location=Sumy,UA&contentType=json&unitGroup=us&shortColumnNames=0",

                    Headers = "{\"X-Rapidapi-Key\": \"5dcf0e8ad4mshc461e39c1a88700p1ed940jsn25b9db5489fb\"}",

                    Limit=500,

                    DateCreated=DateTime.UtcNow,
                },
                new Profile {
                    Id = 3,

                    Name="open-weather-map",

                    Schema="{\"datetime\":\"list:<items>:dt\",\"temperature\":\"list:<items>:temp:average\",\"t-metrica\":\"k\"}",

                    URL = "https://community-open-weather-map.p.rapidapi.com/climate/month?q=Sumy",

                    Headers = "{\"X-Rapidapi-Key\": \"5dcf0e8ad4mshc461e39c1a88700p1ed940jsn25b9db5489fb\"}",

                    Limit=500,

                    DateCreated=DateTime.UtcNow,
                }
                }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}