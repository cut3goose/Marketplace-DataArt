using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Order.Persistence.Context;
using OnlineShop.Order.Persistence.Repository;
using OnlineShop.Order.Persistence.Repository.Interfaces;

namespace OnlineShop.Order.Domain
{
    public static class OrderModule
    {
        public static IServiceCollection AddOrderModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<OrderDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OnlineShopDb"));
                options.UseSnakeCaseNamingConvention();
            });

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            
            return services;
        }
    }
}
