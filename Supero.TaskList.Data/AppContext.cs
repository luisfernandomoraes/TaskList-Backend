using Microsoft.EntityFrameworkCore;
using Supero.TaskList.Data.Mappings;
using Supero.TaskList.Domain;

namespace Supero.TaskList.Data
{
    public class AppContext: DbContext
    {
        private readonly string _connectionString;

        private DbSet<TodoItem> TodoItem { get; set; }

        public AppContext(string connectionString)
        {
            this._connectionString = connectionString;
        }

#if DEBUG
        
        // Utilizado somente nas migrations
        //TODO: Encontrar uma forma melhor de passar a connection string.
        public AppContext()
        {
            _connectionString =
                "Data Source=127.0.0.1,1433;Initial Catalog=tasklistdb;Persist Security Info=True;User ID=sa;Password=P@ssw0rd0";
        }
#endif

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {            
            modelBuilder.ApplyConfiguration(new TodoItemMap());
            base.OnModelCreating(modelBuilder);            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }
    }
}