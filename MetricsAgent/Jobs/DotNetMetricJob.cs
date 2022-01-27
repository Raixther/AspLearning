using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using MetricsAgent.Models;

using Quartz;

namespace MetricsAgent.Jobs
{
	public class DotNetMetricJob : IJob
	{
        private IMetricsRepository<DotNetMetric> _repository;

        private PerformanceCounter _dotnetCounter;

        public Task Execute(IJobExecutionContext context)
        {
            var gc_heap_size = Convert.ToInt32(_dotnetCounter.NextValue());

            var time = TimeSpan.FromSeconds(DateTimeOffset.UtcNow.ToUnixTimeSeconds());

            _repository.Create(new DotNetMetric { Time = time, Value = gc_heap_size });

            return Task.CompletedTask;
        }
    }
}
