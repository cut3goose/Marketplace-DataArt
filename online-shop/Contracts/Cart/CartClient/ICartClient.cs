using System.Threading.Tasks;

namespace OnlineShop.Contracts.Cart.CartClient
{
    public interface ICartClient
    {
        public Task DeleteUserCart();
    }
}