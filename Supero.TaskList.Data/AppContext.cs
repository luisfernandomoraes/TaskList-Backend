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

        public AppContext()
        {
        }

       
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