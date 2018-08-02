namespace Supero.TaskList.Service.Bases
{
    public interface ICommandHandler<T> where T : Command
    {
        void Handle(T command);
    }
}
