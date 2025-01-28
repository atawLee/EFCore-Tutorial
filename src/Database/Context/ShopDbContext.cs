using Microsoft.EntityFrameworkCore;
using Database.Entity;

namespace Database.Context;

public partial class ShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public ShopDbContext(DbContextOptions<ShopDbContext> options) 
        :base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }
}