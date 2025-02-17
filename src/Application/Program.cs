using Repository;
using Database.Context;
using Database.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context, services) =>
    {
        var cons = context.Configuration.GetConnectionString("DefaultConnection");
        services.AddTransient<ProductRepository>(); // 의존성 등록
        services.AddDbContextPool<ShopDbContext>(x => x.UseNpgsql(cons));
    })
    
    .Build();

var service = host.Services.GetRequiredService<ProductRepository>();
var products = service.GetProducts();

// service.AddProduct(new Product
// {
//     Category = ProductCategory.Electronic,
//     ProductName = "전자레인지",
//     Description = "전자레인지 설명",
//     Price = 156000,
//     CreatedAt = DateTimeOffset.UtcNow
// });

foreach (var product in products)
{
    Console.WriteLine(product.Category.ToString());
}

Console.ReadLine();
