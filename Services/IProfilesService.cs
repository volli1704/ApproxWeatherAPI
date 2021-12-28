using System.Collections.Generic;
using ApproxWeatherAPI.Dtos;
using ApproxWeatherAPI.Entities;

namespace ApproxWeatherAPI.Services
{
    public interface IProfilesService
    {
        public List<ProfileDto> GetProfiles();

        public ProfileDto CreateProfile(CreateProfileDto dto);

        public ProfileDto GetProfile(int id);

        public void DeleteProfile(int id);

        public void UpdateProfile(int id, UpdateProfileDto dto);
    }
}