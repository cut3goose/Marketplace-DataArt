using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineShop.Cart.Persistence.Context;
using OnlineShop.Order.Persistence.Context;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.User.Persistence.Context;

namespace OnlineShop
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();

            using var scope = host.Services.CreateScope();

            var serviceProvider = scope.ServiceProvider;

            var userDbContext = serviceProvider.GetRequiredService<UserDbContext>();
            await userDbContext.Database.MigrateAsync();

            var productDbContext = serviceProvider.GetRequiredService<ProductDbContext>();
            await productDbContext.Database.MigrateAsync();

            var orderDbContext = serviceProvider.GetRequiredService<OrderDbContext>();
            await orderDbContext.Database.MigrateAsync();

            var cartDbContext = serviceProvider.GetRequiredService<CartDbContext>();
            await cartDbContext.Database.MigrateAsync();

            host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
