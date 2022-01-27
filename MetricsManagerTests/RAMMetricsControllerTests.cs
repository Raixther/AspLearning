using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MetricsManager.Models;
using Moq;
using MetricsManager;
using Microsoft.Extensions.Logging;

namespace MetricsManagerTests
{
	public class RAMMetricsControllerTests
	{

		private Mock<ILogger<RAMMetricsController>> _loggerMock;

		private Mock<IMetricsRepository<RAMMetric>> _RAMMetricsRepositoryMock;

		public RAMMetricsControllerTests()
		{
			_loggerMock = new Mock<ILogger<RAMMetricsController>>();

			_RAMMetricsRepositoryMock = new Mock<IMetricsRepository<RAMMetric>>();
		}



		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			var controller = new RAMMetricsController(_loggerMock.Object, _RAMMetricsRepositoryMock.Object);

			var result = controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);

			Assert.IsAssignableFrom<IActionResult>(result);

		}

	}
}