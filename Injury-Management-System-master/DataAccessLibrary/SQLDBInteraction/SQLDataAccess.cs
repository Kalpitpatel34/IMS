using Dapper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class SQLDataAccess : ISQLDataAccess
    {
        private readonly IConfiguration _config;

        public string ConnectionStringName { get; set; } = "Default";

        public SQLDataAccess(IConfiguration config)
        {
            _config = config;
        }

        //loads data 
        public async Task<List<T>> LoadData<T, U>(string sql, U parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //query sql database , pass sql statement and params and get back enum of type T
                var data = await connection.QueryAsync<T>(sql, parameters);

                return data.ToList();
            }
        }

        //saves data
        public async Task SaveData<T>(string sql, T parameters)
        {
            string connectionString = _config.GetConnectionString(ConnectionStringName);

            using (IDbConnection connection = new SqlConnection(connectionString))
            {
                //saves data, an exec statement which runs INSERT, UPDATE, DELETE
                //returns nothing but the status of the task result
                await connection.ExecuteAsync(sql, parameters);
            }
        }
    }
}
