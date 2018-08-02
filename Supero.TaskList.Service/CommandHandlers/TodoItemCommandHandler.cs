using System;
using Microsoft.EntityFrameworkCore.Internal;
using Supero.TaskList.Domain;
using Supero.TaskList.Service.Bases;
using Supero.TaskList.Service.Commands.TodoItemCommands;
using Supero.TaskList.Service.Interfaces;
using System.Linq;
using Supero.TaskList.Domain.BusinessExceptions;

namespace Supero.TaskList.Service.CommandHandlers
{
    public class TodoItemCommandHandler :
        ICommandHandler<CreateTodoItemCommand>,
        ICommandHandler<ChangeTodoItemCommand>,
        ICommandHandler<DeleteTodoItemCommand>
    {
        private readonly ITodoItemService _todoItemService;

        public TodoItemCommandHandler(ITodoItemService todoItemService)
        {
            _todoItemService = todoItemService;
        }

        public void Handle(CreateTodoItemCommand command)
        {
            if (_todoItemService.Read(x => x.Description == command.Description).Any())
                command.AddNotification("Description", "Já existe uma tarefa com essa descrição.");

            if (command.Invalid)
                return;

            var todoItem = new TodoItem { Description = command.Description, IsCompleted = command.IsCompleted };

            _todoItemService.Create(todoItem);
        }

        public void Handle(ChangeTodoItemCommand command)
        {
            var todoItem = _todoItemService.Read(x => x.Id == command.Id).FirstOrDefault();
            if (todoItem == null)
                throw new NotFoundException("Objeto não encontrado.", null);

            if (command.Invalid)
                return;

            todoItem.ChangeInformations(command.Description, command.IsCompleted);

            _todoItemService.Update(todoItem);
        }

        public void Handle(DeleteTodoItemCommand command)
        {
            var todoItem = _todoItemService.Read(x => x.Id == command.Id).FirstOrDefault();
            if (todoItem == null)
                throw new NotFoundException("Objeto não encontrado.", null);

            if (command.Invalid)
                return;

            _todoItemService.Delete((long)command.Id);
        }
    }
}