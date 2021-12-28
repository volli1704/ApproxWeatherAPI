using ApproxWeatherAPI.Dtos;
using ApproxWeatherAPI.Entities;

namespace ApproxWeatherAPI
{
    public static class Extensions
    {
        public static ProfileDto AsDto(this Profile item)
        {
            return new ProfileDto
            {
                Id = item.Id,
                Name = item.Name,
                URL = item.URL,
                Headers = item.Headers,
                Schema = item.Schema,
                Limit = item.Limit,
                DateCreated = item.DateCreated,
            };
        }
    }
}