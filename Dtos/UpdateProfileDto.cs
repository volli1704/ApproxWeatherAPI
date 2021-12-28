using System;
using System.ComponentModel.DataAnnotations;

namespace ApproxWeatherAPI.Dtos
{
    public record UpdateProfileDto
    {
        [Required]
        public string Name { get; init; }

        [Required]
        public string URL { get; init; }

        public string Headers { get; init; }

        [Required]
        public string Schema { get; init; }

        [Range(1.0, Double.MaxValue, ErrorMessage = "The field {0} must be greater than {1}.")]
        public int Limit { get; init; }
    }
}