using System;
using System.Collections.Generic;
using System.Linq;
using ApproxWeatherAPI.Dtos;
using ApproxWeatherAPI.Entities;
using ApproxWeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ApproxWeatherAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfileController : ControllerBase
    {
        protected IProfilesService service;

        public ProfileController(IProfilesService service) {
            this.service = service;
        }

        [HttpGet]
        public ActionResult<List<ProfileDto>> GetProfiles()
        {
            return service.GetProfiles();
        }

        [HttpPost]
        public ActionResult<ProfileDto> CreateProfile(CreateProfileDto dto)
        {
            return service.CreateProfile(dto);
        }

        [HttpGet("{id}")]
        public ActionResult<ProfileDto> GetProfile(int id)
        {
            var profile = service.GetProfile(id);

            return (profile is not null) ? profile : NotFound();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProfile(int id)
        {
            try {
                service.DeleteProfile(id);
            } catch (KeyNotFoundException) {
                return NotFound();
            }

            return NoContent();
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProfile(int id, UpdateProfileDto dto)
        {

            try {
                service.UpdateProfile(id, dto);
            } catch (KeyNotFoundException) {
                return NotFound();
            }
            
            return NoContent();
        }
    }
}