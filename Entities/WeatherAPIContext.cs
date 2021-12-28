using System;
using System.Collections.Generic;
using ApproxWeatherAPI.Settings;
using Microsoft.EntityFrameworkCore;

namespace ApproxWeatherAPI.Entities
{
    public partial class WeatherAPIContext : DbContext
    {
        protected IConnectionStringBuilder DSNBuilder;

        public DbSet<APIResult> ApiResults { get; set; }
        public DbSet<Execution> Executions { get; set; }
        public DbSet<Profile> Profiles { get; set; }

        public WeatherAPIContext(IConnectionStringBuilder DSNBuilder) : base()
        {
            this.DSNBuilder = DSNBuilder;
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(DSNBuilder.GetDSN());
        }
    }
}