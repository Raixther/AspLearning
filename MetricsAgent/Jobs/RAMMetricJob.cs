using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using MetricsAgent.Models;

using Quartz;

namespace MetricsAgent.Jobs
{
	public class RAMMetricJob : IJob

	{
        private IMetricsRepository<RAMMetric> _repository;

        private PerformanceCounter _ramCounter;

        public Task Execute(IJobExecutionContext context)
        {

            var ramUsageInPercents = Convert.ToInt32(_ramCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            _repository.Create(new RAMMetric { Time = time, Value = ramUsageInPercents });

            return Task.CompletedTask;
        }
    }
}
