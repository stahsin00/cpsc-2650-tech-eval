using Microsoft.EntityFrameworkCore;

namespace cpsc_2650_tech_eval.Models;

public class TodoContext : DbContext
{
    public TodoContext(DbContextOptions<TodoContext> options)
        : base(options) { }

    public DbSet<TodoItem> TodoItems { get; set; }
}
