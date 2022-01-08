using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson_1.Controllers
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

		public WeatherForecastController(ILogger<WeatherForecastController> logger)
		{
			_logger = logger;
		}

		[HttpGet]
		public IEnumerable<WeatherForecast> Get(DateTime date1, DateTime date2)
		{
			return Enumerable.AsEnumerable<WeatherForecast>(WeatherForecastData.data.FindAll(x=>x.Date>date1||x.Date<date2));
			
		}

		[HttpPut]
		public void Put(DateTime date, int temperature, string summary)
		{
			WeatherForecast forecast = new WeatherForecast();
			forecast.Date = date;
			forecast.TemperatureC = temperature;
			forecast.Summary = summary;		
			WeatherForecastData.data.Add(forecast);
		}
		[HttpPut]
		public void Update(DateTime date, int temperature)
		{
			
			 WeatherForecastData.data.Find(x => x.Date == date).TemperatureC = temperature;

		}
		[HttpDelete]
		public void Delete(DateTime date1, DateTime date2)
		{
			WeatherForecastData.data.RemoveAll(x => x.Date > date1 && x.Date < date2);
		}

	}
}
