using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_movies.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace dotnet_movies.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IRepository _repository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IRepository repository)
        {
            _logger = logger;
            _repository=repository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            _repository.GetAllGenres();
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}
