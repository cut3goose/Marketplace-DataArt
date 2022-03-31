using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Cart.Domain;
using OnlineShop.Contracts.Cart.CartModels;
using OnlineShop.Contracts.Cart.CartProductModels;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Infrastructure.UserIdAccess.Interfaces;
using OnlineShop.Models;
using DomainCart = OnlineShop.Cart.Domain.Models.Cart;

namespace OnlineShop.Controllers
{
    [ApiController]
    public class CartWebApiController : ControllerBase
    {
        private readonly ICartService _cartService;
        private readonly IMapper _mapper;

        public CartWebApiController(ICartService cartService, IMapper mapper)
        {
            _cartService = cartService;
            _mapper = mapper;
        }

        /// <summary>
        /// Getting cart of current user
        /// </summary>
        [HttpGet]
        [Route("/Cart")]
        public async Task<CartModel> GetCartByUser()
        {
            var domainCart = await _cartService.GetCartByUser();
            return _mapper.Map<CartModel>(domainCart);
        }

        /// <summary>
        /// Getting products contained in current user's cart 
        /// </summary>
        [HttpGet]
        [Route("/Cart/CartProductsList/{PageNumber}/{PageSize}")]
        public async Task<PaginatedList<CartProductModel>> GetCartProductsList(PaginationParameters paginationParameters)
        {
            var cartProductsList = await _cartService.GetCartProductsList(paginationParameters);
            return _mapper.Map<PaginatedList<CartProductModel>>(cartProductsList);
        }

        /// <summary>
        /// Adding new product in current user's cart
        /// </summary>
        [HttpPost]
        [Route("/Cart/AddProduct/{productId}/{quantity}")]
        public async Task AddCartProduct(int productId, int quantity)
        {
            var userCart = await _cartService.GetCartByUser();
            var cartProductAddModel = new CartProductAddModel
            {
                Quantity = quantity,
                ProductId = productId,
                CartId = userCart.Id
            };

            await _cartService.AddCartProduct(cartProductAddModel);
        }

        /// <summary>
        /// Updating product quantity in current user's cart
        /// </summary>
        [HttpPut]
        [Route("/Cart/UpdateProduct/{productId}/{quantity}")]
        public async Task UpdateCartProduct(int productId, int quantity)
        {
            var userCart = await _cartService.GetCartByUser();
            var productUpdateModel = new CartProductUpdateModel
            {
                Quantity = quantity,
                CartId = userCart.Id,
                ProductId = productId
            };
            await _cartService.UpdateCartProduct(productUpdateModel);
        }
        
        /// <summary>
        /// Deleting product contained in current user's cart
        /// </summary>
        [HttpDelete]
        [Route("/Cart/DeleteProduct/{productId}")]
        public async Task DeleteCartProduct(int productId)
        {
            var userCart = await _cartService.GetCartByUser();
            
            var deleteModel = new CartProductDeleteModel
            {
                CartId = userCart.Id,
                ProductId = productId
            };
            await _cartService.DeleteCartProduct(deleteModel);
        }
    }
}