using System.Threading.Tasks;
using OnlineShop.Contracts.Cart.CartModels;
using OnlineShop.Contracts.Cart.CartProductModels;
using OnlineShop.Infrastructure.Models.PaginatedList;
using CartProduct = OnlineShop.Cart.Domain.Models.CartProduct;
using ProductCart = OnlineShop.Cart.Persistence.Entities.Cart;

namespace OnlineShop.Cart.Domain
{
    public interface ICartService
    {
        public Task CreateCart(CartCreateModel cartCreateModel);
        public Task<Models.Cart> GetCart(int cartId);
        public Task<Models.Cart> GetCartByUser();
        public Task DeleteCart(int cartId);
        public Task AddCartProduct(CartProductAddModel productAddModel);
        public Task UpdateCartProduct(CartProductUpdateModel productUpdateModel);
        public Task<PaginatedList<CartProduct>> GetCartProductsList(PaginationParameters paginationParameters);
        public Task DeleteCartProduct(CartProductDeleteModel productDeleteModel);
    }
}