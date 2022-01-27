using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using MetricsAgent.Models;

using Quartz;

namespace MetricsAgent.Jobs
{
	public class NetworkMetricJob : IJob

	{
        private IMetricsRepository<NetworkMetric> _repository;

        private PerformanceCounter _networkCounter;

        public Task Execute(IJobExecutionContext context)
        {

            var cpuUsageInPercents = Convert.ToInt32(_networkCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            _repository.Create(new NetworkMetric { Time = time, Value = cpuUsageInPercents });

            return Task.CompletedTask;
        }
    }
}
