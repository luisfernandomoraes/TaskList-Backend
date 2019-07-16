using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Supero.TaskList.Domain;

namespace Supero.TaskList.Data.Mappings
{
    public class TodoItemMap: IEntityTypeConfiguration<TodoItem>
    {
        public void Configure(EntityTypeBuilder<TodoItem> builder)
        {            
            builder.Property(c => c.Id)
                .UseSqlServerIdentityColumn()
                .HasColumnName("Id");

            builder.Property(c => c.Description)
                .HasColumnType("varchar(100)")
                .HasMaxLength(100)
                .IsRequired();

        }
    }
}