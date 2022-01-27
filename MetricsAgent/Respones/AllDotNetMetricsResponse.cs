using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MetricsAgent.DTO;

namespace MetricsAgent.Respones
{
	public class AllDotNetMetricsResponse
	{
		public List<DotNetMetricsDTO> Metrics { get; set; }
	}
}
