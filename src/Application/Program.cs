using Repository;
using Database.Context;
using Database.Entity;
using Microsoft.Data.SqlClient;
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

var service = host.Services;
var context= service.GetRequiredService<ShopDbContext>();
var user = new SqlParameter("user", "johndoe");
context.Database.ExecuteSql($"SELECT * FROM Products WHERE ProductName = {user}");
context.Payments.AddAsync(new CreditCardPayment
{
    Amount = 3000,
    PaymentDate = DateTimeOffset.UtcNow,
    Status = "Completed",
    CardNumber = "0000-0000-0000-1234",
    CardHolder = "John Doe",
    ExpirationDate = "12/23"
});
await context.SaveChangesAsync();

Console.ReadLine();
