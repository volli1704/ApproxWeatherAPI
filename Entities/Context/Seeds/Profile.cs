using System;
using ApproxWeatherAPI.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace ApproxWeatherAPI.Entities.Seeds
{
    public class ProfileSeeder
    {
        public static Profile[] Seed()
        {
            return new Profile[]
                {
                new Profile {
                    Id = 1,

                    Name="visual-crossing",

                    Schema="{\"datetime\":\"$.data..ts\",\"temperature\":\"$.data..temp\",\"t-metrica\":\"f\"}",

                    URL = "https://weatherbit-v1-mashape.p.rapidapi.com/forecast/daily?lat=50.9216&lon=-34.80029",

                    Headers = "{\"X-Rapidapi-Key\": \"5dcf0e8ad4mshc461e39c1a88700p1ed940jsn25b9db5489fb\"}",

                    Limit=500,

                    DateCreated=DateTime.UtcNow,
                },
                new Profile {
                    Id = 2,

                    Name="open-weather-map",

                    Schema="{\"datetime\":\"$.list..*..dt\",\"temperature\":\"$.list..*..temp..average\",\"t-metrica\":\"k\"}",

                    URL = "https://community-open-weather-map.p.rapidapi.com/climate/month?q=Sumy",

                    Headers = "{\"X-Rapidapi-Key\": \"5dcf0e8ad4mshc461e39c1a88700p1ed940jsn25b9db5489fb\"}",

                    Limit=500,

                    DateCreated=DateTime.UtcNow,
                }
            };
        }
    }
}