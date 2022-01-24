using AutoMapper;

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

using static MetricsManager.DTO.CPUMetricsDTO;

namespace MetricsManager.Controllers
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


		[HttpGet("all")]
		public IActionResult GetAll()
		{
			var config = new MapperConfiguration(cfg => cfg.CreateMap<CPUMetric, CPUMetricsDTO>());
			var mapper = config.CreateMapper();
			IList<CPUMetric> metrics = _CPUMetricsRepository.GetAll();
			var response = new AllCPUMetricsResponse()
			{
				Metrics = new List<CPUMetricsDTO>()
			};
			foreach (var metric in metrics)
			{
				response.Metrics.Add(mapper.Map<CPUMetricsDTO>(metric));
			}
			return Ok(response);
		}
	} 
}
