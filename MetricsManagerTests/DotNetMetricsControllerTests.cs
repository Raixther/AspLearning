using MetricsManager.Models;

using MetricsManager;
using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Moq;

using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace MetricsManagerTests
{
	 public class DotNetMetricsControllerTests
	{
		private Mock<ILogger<DotNetMetricsController>> _loggerMock;

		private Mock<IMetricsRepository<DotNetMetric>> _DotNetMetricsRepositoryMock;

		public DotNetMetricsControllerTests()
		{
			_loggerMock = new Mock<ILogger<DotNetMetricsController>>();

			_DotNetMetricsRepositoryMock = new Mock<IMetricsRepository<DotNetMetric>>();
		}



		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			var controller = new DotNetMetricsController(_loggerMock.Object, _DotNetMetricsRepositoryMock.Object);

			var result = controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);

			Assert.IsAssignableFrom<IActionResult>(result);

		}

	}
}
