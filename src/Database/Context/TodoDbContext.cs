using Microsoft.EntityFrameworkCore;
using Database.Entity;

namespace Database.Context;

public partial class TodoDbContext : DbContext
{
    public DbSet<TodoItem> TodoItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}