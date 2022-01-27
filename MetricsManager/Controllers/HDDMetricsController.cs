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
	[Route("api/metrics/hdd")]
	[ApiController]
	public class HDDMetricsController : ControllerBase
	{
		private readonly ILogger<HDDMetricsController> _logger;

		private readonly IMetricsRepository<HDDMetric> _HDDMetricsRepository;

		public HDDMetricsController(ILogger<HDDMetricsController> logger, IMetricsRepository<HDDMetric> HDDMetricsRepository)
		{
			_logger = logger;

			_HDDMetricsRepository = HDDMetricsRepository;
		}



		[HttpGet("agent/{agentID}/from/{fromTime}/to/{toTime}")]

		public IActionResult GetMetricsFromAgent([FromRoute] int agentID, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
		{
			return Ok();
		}
		[HttpGet("all")]
		public IActionResult GetAll()
		{

			var config = new MapperConfiguration(cfg => cfg.CreateMap<HDDMetric, HDDMetricsDTO>());
			var mapper = config.CreateMapper();
			IList<HDDMetric> metrics = _HDDMetricsRepository.GetAll();
			var response = new AllHDDMetricsResponse()
			{
				Metrics = new List<HDDMetricsDTO>()
			};
			foreach (var metric in metrics)
			{
				response.Metrics.Add(mapper.Map<HDDMetricsDTO>(metric));
			}
			return Ok(response);
		}
	}
}
