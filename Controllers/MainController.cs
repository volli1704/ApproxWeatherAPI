using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using ApproxWeatherAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApproxWeatherAPI.Controllers
{
    public class MainController : ControllerBase
    {
        protected IGetWeatherService service;

        public MainController(IGetWeatherService service)
        {
            this.service = service;
        }

        [HttpGet("/")]
        public JsonResult Index()
        {
            return new JsonResult(service.GetForecastAsync().Result);
        }
    }
}