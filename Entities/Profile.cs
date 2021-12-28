using System;
using System.Collections.Generic;

namespace ApproxWeatherAPI.Entities
{
    public record Profile
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string URL { get; set; }

        public string Headers { get; set; }

        public string Schema { get; set; }

        public int Limit { get; set; }

        public DateTime DateCreated { get; set; }

        public DateTime? DateDeleted { get; set; }
    }
}