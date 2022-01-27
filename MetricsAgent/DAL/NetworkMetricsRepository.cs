using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using MetricsAgent.Models;

namespace MetricsManager.DAL
{
	public class NetworkMetricsRepository
	{
      

      
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(NetworkMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("INSERT INTO NetworkMetrics(value, time) VALUES(@value, @time)",
            new
            {
                value = item.Value,

                time = item.Time.TotalSeconds

            });
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("DELETE FROM NetworkMetrics WHERE id=@id");
        }

        public void Update(NetworkMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("UPDATE NetworkMetrics SET value = @value, time = @time WHERE id=@id;");
        }

        public IList<NetworkMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var returnList = connection.Query<NetworkMetric>("SELECT * FROM NetWorkMetrics").ToList<NetworkMetric>();

            return returnList;
        }

        public NetworkMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var result = connection.QuerySingle<NetworkMetric>("SELECT * FROM NetWorkMetrics WHERE id=@id");

            return result;
        }

    }
}


