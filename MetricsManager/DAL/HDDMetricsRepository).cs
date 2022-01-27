using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using MetricsManager.Models;

namespace MetricsManager.DAL
{
	public class HDDMetricsRepository
	{    
      
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(HDDMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("INSERT INTO HDDMetrics(value, time) VALUES(@value, @time)",
            new
            {
                value = item.Value,

                time = item.Time.TotalSeconds

            });
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("DELETE FROM HDDMetrics WHERE id=@id");
        }

        public void Update(HDDMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("UPDATE HDDMetrics SET value = @value, time = @time WHERE id=@id;");
        }

        public IList<HDDMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var returnList = connection.Query<HDDMetric>("SELECT * FROM HDDMetrics").ToList<HDDMetric>();

            return returnList;
        }

        public HDDMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var result = connection.QuerySingle<HDDMetric>("SELECT * FROM HDDMetrics WHERE id=@id");

            return result;
        }

    }
}

