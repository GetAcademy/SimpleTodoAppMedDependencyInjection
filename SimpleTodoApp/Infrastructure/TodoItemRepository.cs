using Dapper;
using SimpleTodoApp.DomainServices;
using SimpleTodoApp.Model;
using System.Data.SqlClient;

namespace SimpleTodoApp.Infrastructure
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private ISqlConnectionFactory _sqlConnectionFactory;
        public TodoItemRepository(ISqlConnectionFactory sqlConnectionFactory)
        {
            _sqlConnectionFactory = sqlConnectionFactory;
        }

        public async Task<IEnumerable<TodoItem>> GetAll()
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = "SELECT Id, Text, Done FROM Todo";
            var todoItems = await conn.QueryAsync<TodoItem>(sql);
            return todoItems;
        }

        public async Task<int> Create(TodoItem todoItem)
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = "INSERT Todo (Id, Text) VALUES (@Id, @Text)";
            var rowsAffected = await conn.ExecuteAsync(sql, todoItem);
            return rowsAffected;
        }

        public async Task<int> Update(TodoItem todoItem)
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = "UPDATE Todo SET Done = @Done WHERE Id = @Id";
            var rowsAffected = await conn.ExecuteAsync(sql, todoItem);
            return rowsAffected;
        }

        public async Task<int> Delete(Guid id)
        {
            var conn = _sqlConnectionFactory.Create();
            const string sql = "DELETE FROM Todo WHERE Id = @Id";
            var rowsAffected = await conn.ExecuteAsync(sql, new { Id = id });
            return rowsAffected;
        }
    }
}
