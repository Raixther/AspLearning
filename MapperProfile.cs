using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;

using MetricsManager.DTO;
using MetricsManager.Models;

namespace MetricsManager
{
	public class MapperProfile:Profile
	{
		public MapperProfile()
		{

			CreateMap<CPUMetric, CPUMetricsDTO>();
			CreateMap<DotNetMetric, DotNetMetricsDTO>();
			CreateMap<HDDMetric, HDDMetricsDTO>();
			CreateMap<NetworkMetric, NetworkMetricsDTO>();
			CreateMap<RAMMetric, RAMMetricsDTO>();
		}
	}
}
