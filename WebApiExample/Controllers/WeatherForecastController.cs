using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApiExample.Models;

namespace WebApiExample.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private ApiExampleContext _context;

        public WeatherForecastController(ApiExampleContext _ctx)
        {
            this._context = _ctx;
        }

        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "Value" + id;
        }

        [HttpPost]
        public string Post(string name)
        {
            return "hello" + name;
        }

        [HttpPut("{id}")]
        public string Put(int id,string name)
        {
            return name + " " + id;
        }

        [HttpDelete]
        public string Delete(int id)
        {
            return id.ToString();
        }
    }
}
