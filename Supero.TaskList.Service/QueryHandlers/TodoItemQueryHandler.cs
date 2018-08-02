using System.Collections.Generic;
using System.Linq;
using Supero.TaskList.Domain;
using Supero.TaskList.Domain.BusinessExceptions;
using Supero.TaskList.Service.Bases;
using Supero.TaskList.Service.Interfaces;
using Supero.TaskList.Service.Queries.TodoItemQueries;


namespace Supero.TaskList.Service.QueryHandlers
{
    public class TodoItemQueryHandler :
        IQueryHandler<GetAllTodoItemsQuery, IEnumerable<TodoItem>>,
        IQueryHandler<GetTodoItemsById, TodoItem>
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemQueryHandler(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public IEnumerable<TodoItem> Handle(GetAllTodoItemsQuery query)
        {
            IEnumerable<TodoItem> todoList;
            if (query.Skip != 0 && query.Top != 0)
                todoList = _todoItemService.ReadAll().OrderBy(x => x.Description).Skip(query.Skip * query.Top)
                    .Take(query.Top);
            else
                todoList = _todoItemService.ReadAll().OrderBy(x => x.Description);

            return todoList;
        }

        public TodoItem Handle(GetTodoItemsById query)
        {
            var todoItem = _todoItemService.Read(x => x.Id == query.Id).FirstOrDefault();

            if (todoItem == null)
                throw new NotFoundException("Objeto não encontrado.", null);

            return todoItem;
        }
    }
}