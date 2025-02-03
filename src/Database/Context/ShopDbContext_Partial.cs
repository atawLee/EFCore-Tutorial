using Database.Entity;
using Microsoft.EntityFrameworkCore;

namespace Database.Context;

public partial class ShopDbContext
{
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DocumentBase>()
            .UseTptMappingStrategy()
            .ToTable("Documents");

    }
}