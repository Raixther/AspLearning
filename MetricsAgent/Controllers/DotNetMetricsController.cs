using MetricsAgent.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsAgent.Controllers
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

		public IActionResult GetMetricsFromAgent([FromRoute] int agentID, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
		{
			return Ok();
		}
	}
}
