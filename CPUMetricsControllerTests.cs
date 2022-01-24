using MetricsManager.Controllers;
using System;
using Xunit;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Microsoft.Extensions.Logging;
using MetricsManager.Models;
using MetricsManager;

namespace MetricsManagerTests
{
	public class CPUMetricsControllerTests
	{

		private Mock<ILogger<CPUMetricsController>> _loggerMock;

		private Mock<IMetricsRepository<CPUMetric>> _CPUMetricsRepositoryMock;

		public CPUMetricsControllerTests()
		{
			_loggerMock = new Mock<ILogger<CPUMetricsController>>();
			
			_CPUMetricsRepositoryMock = new Mock<IMetricsRepository<CPUMetric>>();
		}

		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			var controller = new CPUMetricsController(_loggerMock.Object, _CPUMetricsRepositoryMock.Object);

			var result = controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);

			Assert.IsAssignableFrom<IActionResult>(result);

		}
	}
	
}
