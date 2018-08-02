using System;
using System.Collections.Generic;
using Supero.TaskList.Domain;
using Supero.TaskList.Domain.Interfaces;
using Supero.TaskList.Service.Bases;
using Supero.TaskList.Service.Interfaces;

namespace Supero.TaskList.Service
{
    public class TodoItemService : ServiceBase<TodoItem>, ITodoItemService
    {
        private readonly IRepository<TodoItem> _todoItemRepository;

        public TodoItemService(IRepository<TodoItem> todoItemRepository):base(todoItemRepository)
        {
            _todoItemRepository = todoItemRepository ?? throw new ArgumentNullException(nameof(todoItemRepository));
        }

        public IEnumerable<TodoItem> GetAllTodoItems()
        {
            return _todoItemRepository.GetAll();
        }
    }
}