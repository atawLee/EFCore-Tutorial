using Microsoft.EntityFrameworkCore;
using Database.Entity;

namespace Database.Context;

public partial class ShopDbContext : DbContext
{
    #region TPC
    public DbSet<SystemLog> SystemLogs { get; set; }
    public DbSet<ErrorLog> ErrorLogs { get; set; }
    #endregion
    
    #region TPT
    public DbSet<Product> Products { get; set; }
    
    public DbSet<DocumentBase> Documents { get; set; }
    
    public DbSet<TechnicalDocumentBase> TechnicalDocuments { get; set; }
    
    public DbSet<GeneralDocumentBase> GeneralDocuments { get; set; }
    
    public DbSet<ContractDocumentBase> ContractDocuments { get; set; }
    #endregion
    
    #region TPH
    public DbSet<Payment> Payments { get; set; }
    #endregion

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

        modelBuilder.Entity<Payment>()
            .UseTphMappingStrategy()
            .HasDiscriminator<string>("PaymentType") // Discriminator 컬럼 이름 변경
            .HasValue<CreditCardPayment>("CreditCard")
            .HasValue<PayPalPayment>("PayPal")
            .HasValue<BankTransferPayment>("BankTransfer");
    }
}

