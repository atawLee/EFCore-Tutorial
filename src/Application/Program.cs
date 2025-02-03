using Repository;
using Database.Context;
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
foreach (var product in products)
{
    Console.WriteLine(product.ProductName);
}

Console.ReadLine();
