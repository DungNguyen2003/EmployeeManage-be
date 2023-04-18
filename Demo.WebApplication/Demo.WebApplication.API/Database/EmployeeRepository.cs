using Demo.WebApplication.API.Entities;
using MySqlConnector;
using System.Data;

namespace Demo.WebApplication.API.Database
{
    public class EmployeeRepository : IEmployeeRepository
    {
        #region Field
        private readonly string _connectionString = "Server=18.179.16.166;Port=3306;Database=MISA.HOU2023_NVDUNG;Uid=nvmanh;Pwd=12345678;";
        #endregion

        #region Method
        public IDbConnection GetOpenConnection()
        {
            var mySqlConnection = new MySqlConnection(_connectionString);
            mySqlConnection.Open();
            return mySqlConnection;
        }

        public Employee QueryFirstOrDefault(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null)
        {
            throw new NotImplementedException();
        } 
        #endregion
    }
}
