using Flunt.Notifications;
using Flunt.Validations;

namespace Supero.TaskList.Service.Bases
{
    public abstract class Query : Notifiable, IValidatable
    {
        public abstract  void Validate();
    }
}
