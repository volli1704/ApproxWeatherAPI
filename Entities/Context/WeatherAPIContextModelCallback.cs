using System;
using Microsoft.EntityFrameworkCore;

namespace ApproxWeatherAPI.Entities
{
    public partial class WeatherAPIContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Profile>().HasData(Seeds.ProfileSeeder.Seed());

            base.OnModelCreating(modelBuilder);
        }
    }
}