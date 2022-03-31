using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Contracts.Payment;
using OnlineShop.Payment.Domain.Client;

namespace OnlineShop.Payment.Domain
{
    public static class PaymentModule
    {
        public static IServiceCollection AddPaymentModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPaymentService, PaymentService>();
            services.AddScoped<IPaymentClient, PaymentClient>();

            return services;
        }
    }
}