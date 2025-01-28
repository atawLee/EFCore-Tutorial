using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Database.Entity;

public class Product
{
    [Key]
    public int ProductId { get; set; }

    [Required]
    [MaxLength(255)]
    public string ProductName { get; set; }

    [MaxLength(500)]
    public string? Description { get; set; }

    [Column(TypeName = "decimal(10,2)")]
    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    [MaxLength(255)]
    public string? ImageUrl { get; set; }

    public DateTimeOffset CreatedAt { get; set; } = DateTime.UtcNow;
}