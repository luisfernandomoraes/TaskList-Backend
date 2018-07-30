using System.Collections.Generic;
using Supero.TaskList.Domain;

namespace Supero.TaskList.Service.Interfaces
{
    public interface ITodoItemService
    {
        IEnumerable<TodoItem> GetAllTodoItems();
    }
}