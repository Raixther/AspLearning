using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MetricsAgent.DTO;

namespace MetricsAgent.Respones
{
	public class AllHDDMetricsResponse
	{
		public List<HDDMetricsDTO> Metrics { get; set; }
	}
}
