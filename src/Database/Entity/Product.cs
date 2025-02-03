using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace Database.Entity;

public class Product
{
    [Key]
    public int ProductId { get; set; }
    
    public ProductCategory Category { get; set; }

    [Required]
    [MaxLength(255)]
    public string ProductName { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
}

public class ElectronicProduct : Product
{
    public int WarrantyPeriod { get; set; } 
}

public class FoodProduct : Product
{
    public DateTimeOffset ExpiryDate { get; set; }
}

public class ClothingProduct : Product
{
    public string Size { get; set; }
} 
