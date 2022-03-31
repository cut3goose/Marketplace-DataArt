using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Cart.Persistence.Context;
using OnlineShop.Cart.Persistence.Repositories;
using OnlineShop.Cart.Persistence.Repositories.Interfaces;
using OnlineShop.Contracts.Cart.CartClient;

namespace OnlineShop.Cart.Domain
{
    public static class CartModule
    {
        public static IServiceCollection AddCartModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<CartDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OnlineShopDb"));
                options.UseSnakeCaseNamingConvention();
            });

            services.AddScoped<ICartService, CartService>();
            services.AddScoped<ICartRepository, CartRepository>();
            services.AddScoped<ICartProductRepository, CartProductRepository>();
            services.AddScoped<ICartClient, CartClient>();
            
            return services;
        }
    }
}
