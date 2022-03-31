using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OnlineShop.Cart.Domain;
using OnlineShop.Contracts.Order.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Infrastructure.UserIdAccess.Interfaces;
using OnlineShop.Order.Domain;
using OnlineShop.Payment.Domain;
using OnlineShop.Tests.Helpers;
using OnlineShop.Tests.MockServices;

namespace OnlineShop.Tests.Order
{
    [TestFixture]
    public class OrderServiceTests
    {
        [Test]
        public async Task CreateOrder_CreatingNewOrder_OrderFoundInListReturnedByGetAllOrders()
        {
            var serviceCollection = InitializeServices();
            using (var provider = serviceCollection.BuildServiceProvider())
            {
                var address = "ne dom & ne ulitsa";
                var orderCreateModel = new OrderCreateModel
                {
                    Address = address
                };

                var orderService = provider.GetService<IOrderService>();

                await orderService.CreateOrder(orderCreateModel);
                var foundOrders = await orderService
                    .GetAllOrdersByUser(new PaginationParameters{PageNumber = 1, PageSize = 1});
                var foundAddedOrder = foundOrders.PageData.FirstOrDefault(o => o.Address == address);
            
                Assert.NotNull(foundAddedOrder); 
            }
        }

        #region Auxiliary

        private IServiceCollection InitializeServices()
        {
            var serviceCollection = new ServiceCollection();

            var config = TestsIConfigurationBuilder.GetIConfigurationRoot();
            serviceCollection.AddCartModule(config);
            serviceCollection.AddOrderModule(config);
            serviceCollection.AddPaymentModule(config);
            serviceCollection.AddScoped<IUserIdService, MockUserIdService>();
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            return serviceCollection;
        }

        #endregion
    }
}