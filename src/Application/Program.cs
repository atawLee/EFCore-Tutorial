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

var service = host.Services;
var context= service.GetRequiredService<ShopDbContext>();

context.Payments.AddAsync(new CreditCardPayment
{
    Amount = 3001,
    PaymentDate = DateTimeOffset.UtcNow,
    Status = "Completed",
    CardNumber = "0000-0000-0000-1234",
    CardHolder = "John Doe",
    ExpirationDate = "12/23"
});

var list = await context.Payments.OfType<CreditCardPayment>().ToListAsync();
foreach (var creditCardPayment in list)
{
    Console.WriteLine($"Id: {creditCardPayment.Id}, Amount: {creditCardPayment.Amount}, PaymentDate: {creditCardPayment.PaymentDate}, Status: {creditCardPayment.Status}, CardNumber: {creditCardPayment.CardNumber}, CardHolder: {creditCardPayment.CardHolder}, ExpirationDate: {creditCardPayment.ExpirationDate}");
}

await context.SaveChangesAsync();

Console.ReadLine();
