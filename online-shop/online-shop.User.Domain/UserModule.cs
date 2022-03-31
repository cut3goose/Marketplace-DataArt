using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.User.Persistence.Context;

namespace OnlineShop.User.Domain
{
    public static class UserModule
    {
        public static IServiceCollection AddUserModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<UserDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OnlineShopDb"));
                options.UseSnakeCaseNamingConvention();
            });

            services.AddIdentity<Persistence.Entities.User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.SignIn.RequireConfirmedAccount = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
            })
                .AddEntityFrameworkStores<UserDbContext>();

            services.AddAuthentication();

            return services;
        }
    }
}
