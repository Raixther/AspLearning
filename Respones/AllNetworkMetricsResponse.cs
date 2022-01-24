using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MetricsManager.DTO;

namespace MetricsManager.Respones
{
	public class AllNetworkMetricsResponse
	{
		public List<NetworkMetricsDTO> Metrics { get; set; }

	}
}
