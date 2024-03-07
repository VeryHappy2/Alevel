using Infrastructure;
using Infrastructure.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Controllers
{
	[ApiController]
	[Authorize(Policy = AuthPolicy.AllowEndUserPolicy)]
	[Route(ComponentDefaults.DefaultRoute)]
	public class BasketBffController : ControllerBase
	{
		private static readonly string[] Summaries = new[]
		{
			"Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
		};

		private readonly ILogger<BasketBffController> _logger;

		public BasketBffController(ILogger<BasketBffController> logger)
		{
			_logger = logger;
		}

		[HttpPost]
		[AllowAnonymous]
		public IEnumerable<WeatherForecast> Unknown1()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}

		[HttpPost]
		public IEnumerable<WeatherForecast> Unknown2()
		{
			return Enumerable.Range(1, 5).Select(index => new WeatherForecast
			{
				Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
				TemperatureC = Random.Shared.Next(-20, 55),
				Summary = Summaries[Random.Shared.Next(Summaries.Length)]
			})
			.ToArray();
		}
	}
}
