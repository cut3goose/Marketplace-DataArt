using System.Threading.Tasks;
using OnlineShop.Cart.Persistence.Entities;
using OnlineShop.Infrastructure.Models.PaginatedList;

namespace OnlineShop.Cart.Persistence.Repositories.Interfaces
{
    public interface ICartProductRepository
    {
        public Task AddCartProduct(CartProduct cartProduct);
        public Task UpdateCartProduct(CartProduct cartProduct);
        public Task<CartProduct> GetCartProduct(CartProduct cartProduct);
        public Task<PaginatedList<CartProduct>> GetCartProductsPaginatedList(PaginationParameters paginationParams);
        public Task DeleteCartProduct(CartProduct cartProductToDelete);
    }
}