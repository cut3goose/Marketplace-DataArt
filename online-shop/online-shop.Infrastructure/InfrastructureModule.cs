using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Infrastructure.UserIdAccess;
using OnlineShop.Infrastructure.UserIdAccess.Interfaces;

namespace OnlineShop.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IUserIdService, UserIdService>();

            return services;
        }
    }
}