using AutoMapper;

using MetricsManager.DAL;
using MetricsManager.DTO;
using MetricsManager.Models;
using MetricsManager.Respones;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
	[Route("api/metrics/dotnet")]
	[ApiController]
	public class DotNetMetricsController : ControllerBase
	{
		private readonly ILogger<DotNetMetricsController> _logger;

		private readonly IMetricsRepository<DotNetMetric> _DotNetMetricsRepository;

		public DotNetMetricsController(ILogger<DotNetMetricsController> logger, IMetricsRepository<DotNetMetric> DotNetMetricsRepository)
		{
			_logger = logger;

			_DotNetMetricsRepository = DotNetMetricsRepository;
		}


		[HttpGet("agent/{agentID}/from/{fromTime}/to/{toTime}")]

		public IActionResult GetMetricsFromAgent([FromRoute] int agentID, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
		{
			return Ok();
		}



		[HttpGet("all")]
		public IActionResult GetAll()
		{

			var config = new MapperConfiguration(cfg => cfg.CreateMap<DotNetMetric, DotNetMetricsDTO>());
			var mapper = config.CreateMapper();
			IList<DotNetMetric> metrics = _DotNetMetricsRepository.GetAll();
			var response = new AllDotNetMetricsResponse()
			{
				Metrics = new List<DotNetMetricsDTO>()
			};
			foreach (var metric in metrics)
			{
				response.Metrics.Add(mapper.Map<DotNetMetricsDTO>(metric));
			}
			return Ok(response);
		}
	}
}
