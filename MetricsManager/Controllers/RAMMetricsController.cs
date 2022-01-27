using MetricsManager.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.Controllers
{
	[Route("api/metrics/ram")]
	[ApiController]
	public class RAMMetricsController : ControllerBase
	{
		private readonly ILogger<RAMMetricsController> _logger;

		private readonly IMetricsRepository<RAMMetric> _RAMMetricsRepository;

		public RAMMetricsController(ILogger<RAMMetricsController> logger, IMetricsRepository<RAMMetric> RAMMetricsRepository)
		{
			_logger = logger;

			_RAMMetricsRepository = RAMMetricsRepository;
		}



		[HttpGet("agent/{agentID}/from/{fromTime}/to/{toTime}")]

		public IActionResult GetMetricsFromAgent([FromRoute] int agentID, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
		{
			return Ok();
		}

	}
}
