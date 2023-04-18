using Demo.WebApplication.API.Entities;
using System.Data;

namespace Demo.WebApplication.API.Database
{
    public interface IEmployeeRepository
    {
        public IDbConnection GetOpenConnection();

        public Employee QueryFirstOrDefault(IDbConnection cnn, string sql, object param = null, IDbTransaction transaction = null, int? commandTimeout = null, CommandType? commandType = null);
    }
}
