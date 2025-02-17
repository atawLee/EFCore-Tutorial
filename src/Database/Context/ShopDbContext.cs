using Microsoft.EntityFrameworkCore;
using Database.Entity;

namespace Database.Context;

public partial class ShopDbContext : DbContext
{
    public DbSet<Product> Products { get; set; }
    
    public DbSet<DocumentBase> Documents { get; set; }
    
    public DbSet<TechnicalDocumentBase> TechnicalDocuments { get; set; }
    
    public DbSet<GeneralDocumentBase> GeneralDocuments { get; set; }
    
    public DbSet<ContractDocumentBase> ContractDocuments { get; set; }
    
    public DbSet<SystemLog> SystemLogs { get; set; }

    public DbSet<ErrorLog> ErrorLogs { get; set; }

    public ShopDbContext(DbContextOptions<ShopDbContext> options) 
        :base(options)
    {
        
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocumentBase>()
            .UseTptMappingStrategy()
            .ToTable("Documents");

        modelBuilder.Entity<Log>()
            .UseTpcMappingStrategy();

    }
}

