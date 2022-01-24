using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using MetricsManager.Models;

namespace MetricsManager.DAL
{
	public class DotNetMetricsRepository
	{
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";
      
        public void Create(DotNetMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("INSERT INTO DotNetMetrics(value, time) VALUES(@value, @time)",
            new
            {
                value = item.Value,

                time = item.Time.TotalSeconds

            });
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("DELETE FROM DotNetMetrics WHERE id=@id");
        }

        public void Update(DotNetMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("UPDATE DotNetMetrics SET value = @value, time = @time WHERE id=@id;");
        }

        public IList<DotNetMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var returnList = connection.Query<DotNetMetric>("SELECT * FROM DotNetMetrics").ToList<DotNetMetric>();

            return returnList;
        }

        public DotNetMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var result = connection.QuerySingle<DotNetMetric>("SELECT * FROM DotNetMetrics WHERE id=@id");

            return result;
        }
    }

}

