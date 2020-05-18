using Dapper;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace VehiculosOnline.Transversal.Repositorios
{
    public class Repository
    {
        #region Propiedades

        private readonly string _connectionString;

        public Repository(string connectionString)
        {
            _connectionString = connectionString;
        }

        #endregion

        #region Get

        public async Task<T> GetAsync<T>(string sqlQuery)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<T>(sqlQuery)).FirstOrDefault();
            }
        }

        public async Task<T> GetAsync<T>(string sqlQuery, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var dynamicParameters = new DynamicParameters(parameters);
                return (await connection.QueryAsync<T>(sqlQuery, dynamicParameters)).FirstOrDefault();
            }
        }

        public async Task<List<T>> GetAllAsync<T>(string sqlQuery)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return (await connection.QueryAsync<T>(sqlQuery)).ToList();
            }
        }

        public async Task<List<T>> GetAllAsync<T>(string sqlQuery, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                var dynamicParameters = new DynamicParameters(parameters);
                return (await connection.QueryAsync<T>(sqlQuery, dynamicParameters)).ToList();
            }
        }

        #endregion

        #region Insert

        public async Task<int> InsertAsync(string sqlQuery, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                sqlQuery += "SELECT CAST(scope_identity() AS int);";
                await connection.OpenAsync();
                return await connection.ExecuteScalarAsync<int>(sqlQuery, parameters);
            }
        }

        #endregion

        #region Update

        public async Task<int> UpdateAsync(string sqlQuery, Dictionary<string, object> parameters)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                return await connection.ExecuteAsync(sqlQuery, parameters);
            }
        }

        #endregion
    }
}