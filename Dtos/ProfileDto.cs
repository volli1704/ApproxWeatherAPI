using System;
using System.ComponentModel.DataAnnotations;

namespace ApproxWeatherAPI.Dtos
{
    public record ProfileDto
    {
        public int Id { get; init; }

        public string Name { get; init; }

        public string URL { get; init; }

        public string Headers { get; init; }

        public string Schema { get; init; }

        public int Limit { get; init; }

        public DateTime DateCreated { get; init; }
    }
}