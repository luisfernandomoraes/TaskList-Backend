using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Supero.TaskList.Data;
using Supero.TaskList.Data.Repository;
using Supero.TaskList.Domain;
using Supero.TaskList.Domain.Interfaces;
using Supero.TaskList.Service;
using Supero.TaskList.Service.Interfaces;

namespace Supero.TaskList.IoC
{
    public class RegisterDependencies
    {
        public static void Register(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(p => new AppContext(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<ITodoItemService, TodoItemService>();
            services.AddScoped<IRepository<TodoItem>, Repository<TodoItem>>();
        }
    }
}