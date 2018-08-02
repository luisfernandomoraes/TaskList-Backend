using Supero.TaskList.Service.Bases;

namespace Supero.TaskList.Service.Queries.TodoItemQueries
{
    public class GetAllTodoItemsQuery : Query
    {
        public int Skip { get; private set; }
        public int Top { get; private set; }

        public GetAllTodoItemsQuery(int skip, int top)
        {
            Skip = skip;
            Top = top;
        }

        public override void Validate() { }
    }
}