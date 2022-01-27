using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using MetricsAgent.Models;

using Quartz;

namespace MetricsAgent.Jobs
{
	public class HDDMetricJob : IJob
	{
        private IMetricsRepository<HDDMetric> _repository;

        private PerformanceCounter _hddCounter;

        public Task Execute(IJobExecutionContext context)
        {

            var hddUsageInPercents = Convert.ToInt32(_hddCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            _repository.Create(new HDDMetric { Time = time, Value = hddUsageInPercents });

            return Task.CompletedTask;
        }
    }
}
