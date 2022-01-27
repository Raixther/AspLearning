using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using MetricsAgent.DTO;

namespace MetricsAgent.Respones
{
	public class AllCPUMetricsResponse
	{
	    public List<CPUMetricsDTO> Metrics { get; set; }
	}
}
