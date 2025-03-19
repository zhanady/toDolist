// Components/TodoComponent.razor.cs
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using TodoListApp.Data;
using TodoListApp.Services;

namespace TodoListApp.Components
{
    public class TodoComponent : ComponentBase
    {
        [Inject]
        public ITodoService TodoService { get; set; }

        public List<TodoItem> Todos { get; set; } = new();
        public string NewTodoTitle { get; set; }

        protected override async Task OnInitializedAsync()
        {
            Todos = await TodoService.GetTodosAsync();
        }

        public async Task AddTodo()
        {
            if (!string.IsNullOrWhiteSpace(NewTodoTitle))
            {
                var newTodo = new TodoItem { Title = NewTodoTitle, IsCompleted = false };
                await TodoService.AddTodoAsync(newTodo);
                Todos = await TodoService.GetTodosAsync();
                NewTodoTitle = string.Empty;
            }
        }

        public async Task ToggleCompletion(TodoItem item)
        {
            item.IsCompleted = !item.IsCompleted;
            await TodoService.UpdateTodoAsync(item);
        }

        public async Task DeleteTodoItem(int id)
        {
            await TodoService.DeleteTodoAsync(id);
            Todos = await TodoService.GetTodosAsync();
        }
    }
}
