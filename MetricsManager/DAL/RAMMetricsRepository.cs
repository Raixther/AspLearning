using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using MetricsManager.Models;

namespace MetricsManager.DAL
{
	public class RAMMetricsRepository 
	{
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";



        public void Create(RAMMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("INSERT INTO RAMMetrics(value, time) VALUES(@value, @time)",
            new
            {
                value = item.Value,

                time = item.Time.TotalSeconds

            });
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("DELETE FROM RAMMetrics WHERE id=@id");
        }

        public void Update(RAMMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("UPDATE RAMMetrics SET value = @value, time = @time WHERE id=@id;");
        }

        public IList<RAMMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var returnList = connection.Query<RAMMetric>("SELECT * FROM RAMMetrics").ToList<RAMMetric>();

            return returnList;
        }

        public RAMMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var result = connection.QuerySingle<RAMMetric>("SELECT * FROM RAMMetrics WHERE id=@id");

            return result;
        }
    }
}

