using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using OnlineShop.Cart.Domain;
using OnlineShop.Contracts.Cart.CartModels;
using OnlineShop.Contracts.Cart.CartProductModels;
using OnlineShop.Infrastructure.UserIdAccess.Interfaces;
using OnlineShop.Tests.Helpers;
using OnlineShop.Tests.MockServices;

namespace OnlineShop.Tests.Cart.Integration
{
    [TestFixture]
    public class CartServiceTests
    {
        private ServiceProvider _provider;
        private ICartService _cartService;
        private IUserIdService _userIdService;

        #region Cart Product Tests

        [Test]
        public async Task AddCartProduct_AddingNewCartProductToCart_CartReturnAddedProduct()
        {
            // Initialize
            const int quantity = 3;
            const int productId = 5;

            // Create Cart
            await _cartService.CreateCart(new CartCreateModel {UserId = _userIdService.GetUserId()});
            var createdCart = await _cartService.GetCartByUser();

            // Add product in cart
            var cartProductCreateModel = new CartProductAddModel
            {
                Quantity = quantity,
                CartId = createdCart.Id,
                ProductId = productId
            };
            await _cartService.AddCartProduct(cartProductCreateModel);

            // Get Cart and find Proudct
            var updatedCart = await _cartService.GetCartByUser();
            var foundProduct = updatedCart.CartProducts.FirstOrDefault(p => p.ProductId == productId);

            Assert.NotNull(foundProduct);
        }

        [Test]
        public async Task AddCartProduct_AddingProductTwice_CartReturnsAddedProductWithQuantityGreaterBy1()
        {
            var quantity = 1;
            var productId = 5;

            // Create Cart
            await _cartService.CreateCart(new CartCreateModel {UserId = _userIdService.GetUserId()});
            var createdCart = await _cartService.GetCartByUser();
            
            var product = new CartProductAddModel
            {
                Quantity = quantity,
                CartId = createdCart.Id,
                ProductId = productId
            };

            await _cartService.AddCartProduct(product);
            await _cartService.AddCartProduct(product);
            
            var cart = await _cartService.GetCartByUser();
            var foundProduct = cart.CartProducts.FirstOrDefault(p =>
                p.Quantity == quantity + 1 && p.CartId == cart.Id && p.ProductId == productId);
            
            Assert.NotNull(foundProduct);
        }

        #endregion

        #region Cart Tests

        [Test]
        public async Task CreateCart_CreatingNewCart_CartFoundByUserId()
        {
            var cartCreateModel = new CartCreateModel
            {
                UserId = _userIdService.GetUserId()
            };
            
            await _cartService.CreateCart(cartCreateModel);
            var foundCart = await _cartService.GetCartByUser();
            
            Assert.NotNull(foundCart);
        }

        [Test]
        public async Task DeleteCart_CreatingNewCartAndDeletingIt_CartAutoCreatedAgain()
        {
            var cartCreateModel = new CartCreateModel
            {
                UserId = _userIdService.GetUserId()
            };
            
            await _cartService.CreateCart(cartCreateModel);
            var createdCart = await _cartService.GetCartByUser();
            await _cartService.DeleteCart(createdCart.Id);
            var foundCart = await _cartService.GetCartByUser();
            
            Assert.NotNull(foundCart);
        }

        #endregion

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
            
            serviceCollection.AddScoped<IUserIdService, MockUserIdService>();
            serviceCollection.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            
            return serviceCollection;
        }

        private void AssignServicesFields()
        {
            _cartService = _provider.GetRequiredService<ICartService>();
            _userIdService = _provider.GetRequiredService<IUserIdService>();
        }

        #endregion
    }
}