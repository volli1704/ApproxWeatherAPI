using System;
using System.Collections.Generic;
using System.Linq;
using ApproxWeatherAPI.Dtos;
using ApproxWeatherAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApproxWeatherAPI.Services
{
    public class ProfilesService : IProfilesService
    {
        private readonly WeatherAPIContext context;

        public ProfilesService(WeatherAPIContext context) {
            this.context = context;
        }

        public ProfileDto CreateProfile(CreateProfileDto dto)
        {
            var profile = new Profile();
            profile.Name = dto.Name;
            profile.URL = dto.URL;
            profile.Schema = dto.Schema;
            profile.Limit = dto.Limit;
            profile.Headers = dto.Headers;
            profile.DateCreated = DateTime.UtcNow;

            context.Profiles.Add(profile);
            var result = context.SaveChanges();

            return profile.AsDto();
        }

        public void DeleteProfile(int id)
        {
            var profile = ( from p in context.Profiles
                            where p.Id == id
                            select p ).First();

            if (profile is null) {
                throw new KeyNotFoundException();
            }
            
            context.Profiles.Remove(profile);
            context.SaveChanges();
        }

        public ProfileDto GetProfile(int id)
        {
            var profile = ( from p in context.Profiles
                            where p.Id == id
                            select p ).FirstOrDefault();
            
            return profile?.AsDto();
        }

        public List<ProfileDto> GetProfiles()
        {
            return context.Profiles.Select(item => item.AsDto()).ToList();
        }

        public void UpdateProfile(int id, UpdateProfileDto dto)
        {
            var profile = ( from p in context.Profiles
                            where p.Id == id
                            select p ).First();

            if (profile is null) {
                throw new KeyNotFoundException();
            }
            
            context.Entry(profile).CurrentValues.SetValues(dto);
            context.SaveChanges();
        }
  }
}