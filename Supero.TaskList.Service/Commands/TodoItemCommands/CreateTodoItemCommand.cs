using System;
using Flunt.Br.Validation;
using Flunt.Validations;
using Supero.TaskList.Domain;
using Supero.TaskList.Service.Bases;

namespace Supero.TaskList.Service.Commands.TodoItemCommands
{
    public class CreateTodoItemCommand : Command
    {
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public CreateTodoItemCommand(string description, bool isCompleted)
        {
            Description = description;
            IsCompleted = isCompleted;
        }

        public override void Validate()
        {
            AddNotifications(
            new Contract()
                .HasMinLen(Description, 3, nameof(Description), "A descrição deve ter no minimo 3 letras"));
        }
    }
}