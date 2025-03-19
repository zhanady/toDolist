// Services/ITodoService.cs
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApp.Data;

namespace TodoListApp.Services
{
    public interface ITodoService
    {
        Task<List<TodoItem>> GetTodosAsync();
        Task AddTodoAsync(TodoItem item);
        Task UpdateTodoAsync(TodoItem item);
        Task DeleteTodoAsync(int id);
    }
}
