using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Cart.Persistence.Context;
using OnlineShop.Cart.Persistence.Repositories.Interfaces;
using OnlineShop.Infrastructure.DataAccess;
using ProductCart = OnlineShop.Cart.Persistence.Entities.Cart;

namespace OnlineShop.Cart.Persistence.Repositories
{
    public class CartRepository : BaseRepository<CartDbContext, ProductCart>, ICartRepository
    {
        public CartRepository(CartDbContext dbContext) : base(dbContext) { }
        
        public async Task CreateCart(string userId)
        {
            var cart = new ProductCart
            {
                UserId = userId
            };
            
            await _dbContext.Carts.AddAsync(cart);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<ProductCart> GetCart(int cartId)
        {
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(c => c.Id == cartId);
            return cart;
        }

        public async Task<ProductCart> GetCartByUser(string userId)
        {
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(c => c.UserId == userId);
            return cart;
        }

        public async Task DeleteCart(int cartId)
        {
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(c => c.Id == cartId);
            
            _dbContext.Carts.Remove(cart);
            await _dbContext.SaveChangesAsync();
        }
    }
}