using System.Threading.Tasks;
using ProductCart = OnlineShop.Cart.Persistence.Entities.Cart;

namespace OnlineShop.Cart.Persistence.Repositories.Interfaces
{
    public interface ICartRepository
    {
        public Task CreateCart(string userId);
        public Task<ProductCart> GetCart(int cartId);
        public Task<ProductCart> GetCartByUser(string userId);
        public Task DeleteCart(int cartId);
    }
}