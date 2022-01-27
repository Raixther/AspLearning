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
	[Route("api/metrics/network")]
	[ApiController]
	public class NetworkMetricsController : ControllerBase
	{
		private readonly ILogger<NetworkMetricsController> _logger;

		private readonly IMetricsRepository<NetworkMetric> _NetworkMetricsRepository;

		public NetworkMetricsController(ILogger<NetworkMetricsController> logger, IMetricsRepository<NetworkMetric> NetworkMetricsRepository)
		{
			_logger = logger;

			_NetworkMetricsRepository = NetworkMetricsRepository;
		}



		[HttpGet("agent/{agentID}/from/{fromTime}/to/{toTime}")]

		public IActionResult GetMetricsFromAgent([FromRoute] int agentID, [FromRoute] TimeSpan fromTime, [FromRoute] TimeSpan toTime)
		{
			return Ok();
		}
		public IActionResult GetAll()
		{

			var config = new MapperConfiguration(cfg => cfg.CreateMap<HDDMetric, HDDMetricsDTO>());
			var mapper = config.CreateMapper();
			IList<NetworkMetric> metrics = _NetworkMetricsRepository.GetAll();
			var response = new AllNetworkMetricsResponse()
			{
				Metrics = new List<NetworkMetricsDTO>()
			};
			foreach (var metric in metrics)
			{
				response.Metrics.Add(mapper.Map<NetworkMetricsDTO>(metric));
			}
			return Ok(response);
		}
	}
}
