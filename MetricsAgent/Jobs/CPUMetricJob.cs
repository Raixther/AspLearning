using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Diagnostics;
using Quartz;
using MetricsAgent.Models;

namespace MetricsAgent.Jobs
{
	public class CPUMetricJob : IJob
	{
		private IMetricsRepository<CPUMetric> _repository;

		private PerformanceCounter _cpuCounter;

        public Task Execute(IJobExecutionContext context)
        {
        
            var cpuUsageInPercents = Convert.ToInt32(_cpuCounter.NextValue());
     
            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            _repository.Create(new CPUMetric { Time = time, Value = cpuUsageInPercents });

            return Task.CompletedTask;
        }
    }
	
}
