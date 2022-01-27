using MetricsManager;
using MetricsManager.Controllers;
using MetricsManager.Models;
using Microsoft.AspNetCore.Mvc;

using Moq;

using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;



namespace MetricsManagerTests
{
	public class NetworkMetricsControllerTests
	{


		private Mock<ILogger<NetworkMetricsController>> _loggerMock;

		private Mock<IMetricsRepository<NetworkMetric>> _NetworkMetricsRepositoryMock;

		public NetworkMetricsControllerTests()
		{
			_loggerMock = new Mock<ILogger<NetworkMetricsController>>();

			_NetworkMetricsRepositoryMock = new Mock<IMetricsRepository<NetworkMetric>>();
		}



		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			var controller = new NetworkMetricsController(_loggerMock.Object, _NetworkMetricsRepositoryMock.Object);

			var result = controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);

			Assert.IsAssignableFrom<IActionResult>(result);

		}

	}
}
