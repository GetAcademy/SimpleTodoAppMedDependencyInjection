using System.Data.SqlClient;

namespace SimpleTodoApp.DomainServices
{
    public interface ISqlConnectionFactory
    {
        SqlConnection Create();
    }
}
