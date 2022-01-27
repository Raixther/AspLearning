using MetricsManager.Controllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using MetricsManager.Models;
using Moq;
using Microsoft.Extensions.Logging;
using MetricsManager;

namespace MetricsManagerTests
{
	 public class HDDMetricsControllerTests
	{

		private Mock<ILogger<HDDMetricsController>> _loggerMock;

		private Mock<IMetricsRepository<HDDMetric>> _HDDMetricsRepositoryMock;

		public HDDMetricsControllerTests()
		{
			_loggerMock = new Mock<ILogger<HDDMetricsController>>();

			_HDDMetricsRepositoryMock = new Mock<IMetricsRepository<HDDMetric>>();
		}



		[Fact]
		public void GetMetricsFromAgent_ReturnsOk()
		{
			var controller = new HDDMetricsController(_loggerMock.Object, _HDDMetricsRepositoryMock.Object);

			var result = controller.GetMetricsFromAgent(1, TimeSpan.Zero, TimeSpan.Zero);


	

			Assert.IsAssignableFrom<IActionResult>(result);

		}

	}
}
