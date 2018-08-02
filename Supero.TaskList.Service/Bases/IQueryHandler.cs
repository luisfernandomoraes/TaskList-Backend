namespace Supero.TaskList.Service.Bases
{
    public interface IQueryHandler<Q, R> where Q : Query
    {
        R Handle(Q query);
    }
}
