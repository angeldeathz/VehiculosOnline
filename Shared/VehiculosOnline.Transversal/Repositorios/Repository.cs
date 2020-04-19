using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace VehiculosOnline.Transversal.Repositorios
{
    public class Repository
    {
        private readonly string _connectionString;

        public Repository(string ConnectionString)
        {
            _connectionString = ConnectionString;
        }

        public async Task<List<T>> GetAllAsync<T>(string sqlQuery)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<T>(sqlQuery)).ToList();
            }
        }

        public async Task<List<T>> GetAllAsync<T>(string sqlQuery, object parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<T>(sqlQuery, parameters)).ToList();
            }
        }

        public async Task<T> GetAsync<T>(string sqlQuery)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<T>(sqlQuery)).FirstOrDefault();
            }
        }

        public async Task<T> GetAsync<T>(string sqlQuery, object parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<T>(sqlQuery, parameters)).FirstOrDefault();
            }
        }
    }
}