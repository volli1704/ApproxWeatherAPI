using System;

namespace ApproxWeatherAPI.Entities
{
    public record Execution
    {
        public int Id { get; set; }

        public DateTime Datetime { get; set; }

        public int ProfileId { get; set; }

        public Profile Profile { get; set; }

        public int Result { get; set; }
    }

}