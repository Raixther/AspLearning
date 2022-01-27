using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MetricsAgent.Models;

namespace MetricsAgent.Controllers
{
	[Route("api/metrics/cpu")]
	[ApiController]
	public class CPUMetricsController : ControllerBase
	{
		private readonly ILogger<CPUMetricsController> _logger;

		private readonly IMetricsRepository<CPUMetric> _CPUMetricsRepository;

		public CPUMetricsController(ILogger<CPUMetricsController> logger, IMetricsRepository<CPUMetric> CPUMetricsRepository)
		{
			_logger = logger;

			_CPUMetricsRepository = CPUMetricsRepository;

		}


		[HttpGet("agent/{agentID}/from/{fromTime}/to/{toTime}")]

		public IActionResult GetMetricsFromAgent([FromRoute] int agentID, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
		{
			return Ok();
		}	
	}
}
