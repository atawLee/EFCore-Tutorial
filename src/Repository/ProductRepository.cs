using Database.Context;
using Database.Entity;

namespace Repository;

public class ProductRepository
{
    private readonly ShopDbContext _context;

    public ProductRepository(ShopDbContext context)
    {
        _context = context;
    }
    
    public List<Product> GetProducts()
    {
        return _context.Products.ToList();
    }  
}