using System;
using Flunt.Validations;
using Supero.TaskList.Service.Bases;

namespace Supero.TaskList.Service.Commands.TodoItemCommands
{
    public class DeleteTodoItemCommand : Command
    {
        public decimal Id { get; set; }

        public DeleteTodoItemCommand(long id)
        {
            Id = id;
        }

        public override void Validate()
        {
            AddNotifications(new Contract()
                .IsGreaterThan(Id, 0, nameof(Id), "Valor deve ser um indentificador válido"));
        }
    }
}