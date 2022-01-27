using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MetricsManager.DTO
{
	public class DotNetMetricsDTO
	{
		public int Id { get; set; }

		public int Value { get; set; }

		public TimeSpan Time { get; set; }

	}
}

