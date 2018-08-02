using Supero.TaskList.Service.Bases;

namespace Supero.TaskList.Service.Queries.TodoItemQueries
{
    public class GetTodoItemsById: Query
    {
        public long Id { get; set; }

        public GetTodoItemsById(long id)
        {
            Id = id;
        }

        public override void Validate() { }
    }
}