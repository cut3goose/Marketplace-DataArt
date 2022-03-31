using System.Threading.Tasks;
using OnlineShop.Cart.Domain;

namespace OnlineShop.Contracts.Cart.CartClient
{
    public class CartClient : ICartClient
    {
        private ICartService _cartService;
        
        public CartClient(ICartService cartService)
        {
            _cartService = cartService;
        }
        
        public async Task DeleteUserCart()
        {
            var userCart = await _cartService.GetCartByUser();
            await _cartService.DeleteCart(userCart.Id);
        }
    }
}