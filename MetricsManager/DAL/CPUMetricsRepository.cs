using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Threading.Tasks;

using Dapper;

using MetricsManager.Models;

namespace MetricsManager.DAL
{
	public class CPUMetricsRepository : IMetricsRepository<CPUMetric>
	{
        private const string ConnectionString = "Data Source=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";

        public void Create(CPUMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("INSERT INTO CPUMetrics(value, time) VALUES(@value, @time)",
            new
            {
                value = item.Value,

                time = item.Time.TotalSeconds

            });   
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("DELETE FROM CPUmetrics WHERE id=@id");     
        }

        public void Update(CPUMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);

            connection.Execute("UPDATE CPUmetrics SET value = @value, time = @time WHERE id=@id;");
        }

        public IList<CPUMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);

            var returnList =  connection.Query<CPUMetric>("SELECT * FROM CPUmetrics").ToList<CPUMetric>();

            return returnList;
        }

        public CPUMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);

             var result =   connection.QuerySingle<CPUMetric>("SELECT * FROM CPUmetrics WHERE id=@id");

             return result;            
        }
    }

}

