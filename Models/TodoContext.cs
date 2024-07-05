using Microsoft.EntityFrameworkCore;

namespace cpsc_2650_tech_eval.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TodoItem>(entity =>
        {
            entity.HasKey(e => e.Id);
            entity.Property(e => e.Name).IsRequired();
            entity.Property(e => e.IsComplete).HasDefaultValue(false);
        });
    }
}
