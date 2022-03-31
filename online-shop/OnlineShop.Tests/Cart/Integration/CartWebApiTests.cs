using System;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OnlineShop.Cart.Domain;
using OnlineShop.Cart.Domain.Mappings;
using OnlineShop.Controllers;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Infrastructure.UserIdAccess.Interfaces;
using OnlineShop.Mappings;
using OnlineShop.Tests.Helpers;
using OnlineShop.Tests.MockServices;

namespace OnlineShop.Tests.Cart.Integration
{
    [TestFixture]
    public class CartWebApiTests
    {
        private ServiceProvider _provider;
        private CartWebApiController _cartWebApi;

        [Test]
        public async Task AddProduct_AddProductInCart_ProductFoundInCart()
        {
            var productId = 1;
            var defaultQuantity = 1;
            
            await _cartWebApi.AddCartProduct(defaultQuantity, productId);
            var foundList = await _cartWebApi
                .GetCartProductsList(new PaginationParameters {PageNumber = 1, PageSize = 1});
            
            Assert.NotNull(foundList.PageData
                .First(p => p.ProductId == productId));
        }
        
        [Test]
        public async Task UpdateProduct_AddProductInCartAndIncreaseQuantity_ProductFoundInCart()
        {
            var productId = 1;
            var defaultQuantity = 1;
            var newQuantity = defaultQuantity + 1;
            
            await _cartWebApi.AddCartProduct(defaultQuantity, productId);
            await _cartWebApi.UpdateCartProduct(productId, newQuantity);
            var foundList = await _cartWebApi
                .GetCartProductsList(new PaginationParameters {PageNumber = 1, PageSize = 100});
            
            var foundProduct = foundList.PageData.First(p => p.ProductId == productId && p.Quantity == newQuantity);
            Assert.NotNull(foundProduct);
        }

        [Test]
        public async Task DeleteCartProduct_AddProductInCartThenDeleteIt_ProductNotFound()
        {
            var productId = 1;
            var defaultQuantity = 1;
            
            await _cartWebApi.AddCartProduct(defaultQuantity, productId);
            await _cartWebApi.DeleteCartProduct(productId);
            var foundList = await _cartWebApi
                .GetCartProductsList(new PaginationParameters {PageNumber = 1, PageSize = 100});
            
            var foundProduct = foundList.PageData.FirstOrDefault(p => p.ProductId == productId);
            Assert.IsNull(foundProduct);
        }

        #region Init

        [SetUp]
        public void SetUpTests()
        {
            _provider = InitializeServices().BuildServiceProvider();
            AssignServicesFields();
        }
        
        private static ServiceCollection InitializeServices()
        {
            var serviceCollection = new ServiceCollection();

            var config = TestsIConfigurationBuilder.GetIConfigurationRoot();
            serviceCollection.AddCartModule(config);
            
            serviceCollection.AddAutoMapper(Assembly.GetAssembly(typeof(MappingProfile)));
            serviceCollection.AddAutoMapper(Assembly.GetAssembly(typeof(CartMappingProfile)));
            serviceCollection.AddScoped<IUserIdService, MockUserIdService>();
            serviceCollection.AddScoped<ICartService, CartService>();
            serviceCollection.AddScoped<CartWebApiController>();

            return serviceCollection;
        }

        private void AssignServicesFields()
        {
            _cartWebApi = _provider.GetRequiredService<CartWebApiController>();
        }

        #endregion
    }
}