using SimpleTodoApp.Infrastructure;
using SimpleTodoApp.Model;

namespace SimpleTodoApp.DomainServices
{
    public interface ITodoItemRepository
    {
        Task<IEnumerable<TodoItem>> GetAll();
        Task<int> Create(TodoItem todoItem);
        Task<int> Update(TodoItem todoItem);
        Task<int> Delete(Guid id);
    }
}
