using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Cart.Persistence.Entities;
using OnlineShop.Cart.Persistence.Repositories.Interfaces;
using OnlineShop.Contracts.Cart.CartModels;
using OnlineShop.Contracts.Cart.CartProductModels;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Infrastructure.UserIdAccess.Interfaces;
using DomainCart = OnlineShop.Cart.Domain.Models.Cart;
using DomainCartProduct = OnlineShop.Cart.Domain.Models.CartProduct;

namespace OnlineShop.Cart.Domain
{
    public class CartService : ICartService
    {
        private readonly ICartRepository _cartRepository;
        private readonly ICartProductRepository _cartProductRepository;
        private readonly IUserIdService _userIdService;
        private readonly IMapper _mapper;

        public CartService(ICartRepository cartRepository, ICartProductRepository cartProductRepository, 
            IUserIdService userIdService, IMapper mapper)
        {
            _cartRepository = cartRepository;
            _cartProductRepository = cartProductRepository;
            _userIdService = userIdService;
            _mapper = mapper;
        }
        
        public async Task CreateCart(CartCreateModel cartCreateModel)
        {
            var foundCart = await _cartRepository.GetCartByUser(cartCreateModel.UserId);
            if (foundCart != null) return;
            
            await _cartRepository.CreateCart(cartCreateModel.UserId);
        }

        public async Task<DomainCart> GetCart(int cartId)
        {
            var entityCart = await _cartRepository.GetCart(cartId);
            var cart = _mapper.Map<DomainCart>(entityCart);
            return cart;
        }

        public async Task<DomainCart> GetCartByUser()
        {
            var userId = _userIdService.GetUserId();
            
            var foundCart = await _cartRepository.GetCartByUser(userId);
            if (foundCart != null) return _mapper.Map<DomainCart>(foundCart);

            var cartCreateModel = new CartCreateModel
            {
                UserId = userId
            };
            
            await CreateCart(cartCreateModel);
            var createdCart = await _cartRepository.GetCartByUser(userId);
            var mappedCart = _mapper.Map<DomainCart>(createdCart);
            return mappedCart;
        }

        public Task DeleteCart(int cartId)
        {
            return _cartRepository.DeleteCart(cartId);
        }

        public async Task AddCartProduct(CartProductAddModel productAddModel)
        {
            var mappedRepositoryCartProductModel = _mapper.Map<CartProduct>(productAddModel);

            if (await CheckIfProductExists(mappedRepositoryCartProductModel))
            {
                var mappedDomainCartProductModel = _mapper.Map<DomainCartProduct>(productAddModel);
                await UpdateProductQuantity(mappedDomainCartProductModel);
            }
            else
            {
                await _cartProductRepository.AddCartProduct(mappedRepositoryCartProductModel);
            }
        }

        public async Task UpdateCartProduct(CartProductUpdateModel productUpdateModel)
        {
            var cartProductToGet = new CartProduct
            {
                CartId = productUpdateModel.CartId,
                ProductId = productUpdateModel.ProductId
            };
            
            var foundCartProduct = await _cartProductRepository.GetCartProduct(cartProductToGet);
            foundCartProduct.Quantity = productUpdateModel.Quantity;
            
            await _cartProductRepository.UpdateCartProduct(foundCartProduct);
        }

        public async Task<PaginatedList<DomainCartProduct>> GetCartProductsList(PaginationParameters paginationParameters)
        {
            var foundProducts = await _cartProductRepository
                .GetCartProductsPaginatedList(paginationParameters);
            
            var mappedProducts = _mapper.Map<PaginatedList<DomainCartProduct>>(foundProducts);
            return mappedProducts;
        }

        public async Task DeleteCartProduct(CartProductDeleteModel productDeleteModel)
        {
            var cartProductToDelete = new CartProduct
            {
                CartId = productDeleteModel.CartId,
                ProductId = productDeleteModel.ProductId
            };

            await _cartProductRepository.DeleteCartProduct(cartProductToDelete);
        }

        #region Auxiliary

        private async Task<bool> CheckIfProductExists(CartProduct productModel)
        {
            var foundProduct = await _cartProductRepository.GetCartProduct(productModel);
            return foundProduct != null;
        } 
        
        private Task UpdateProductQuantity(DomainCartProduct productModel)
        {
            productModel.Quantity++;
            var cartProductUpdateModel = _mapper.Map<CartProductUpdateModel>(productModel);
            return UpdateCartProduct(cartProductUpdateModel);
        }

        #endregion
    }
}