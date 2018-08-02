using Flunt.Validations;
using Supero.TaskList.Service.Bases;


namespace Supero.TaskList.Service.Commands.TodoItemCommands
{
    public class ChangeTodoItemCommand: Command
    {
        public decimal Id { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }

        public ChangeTodoItemCommand(string description, bool isCompleted)
        {
            Description = description;
            IsCompleted = isCompleted;
        }

        public override void Validate()
        {
            AddNotifications(
                new Contract()
                    .HasMinLen(Description, 3, nameof(Description), "A descrição deve ter no minimo 3 letras")
                    .IsGreaterThan(Id, 0, nameof(Id), "Valor deve ser um indentificador válido"));
        }
    }
}