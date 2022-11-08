using SimpleTodoApp.DomainServices;
using System.Data.SqlClient;

namespace SimpleTodoApp.Infrastructure
{
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        private string _connectionString;
        public SqlConnectionFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        public SqlConnection Create()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
