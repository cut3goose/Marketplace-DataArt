using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Cart.Persistence.Context;
using OnlineShop.Cart.Persistence.Entities;
using OnlineShop.Cart.Persistence.Repositories.Interfaces;
using OnlineShop.Infrastructure.DataAccess;
using OnlineShop.Infrastructure.Models.PaginatedList;

namespace OnlineShop.Cart.Persistence.Repositories
{
    public class CartProductRepository : BaseRepository<CartDbContext, CartProduct>, ICartProductRepository
    {
        public CartProductRepository(CartDbContext dbContext) : base(dbContext) { }
        
        public async Task AddCartProduct(CartProduct cartProduct)
        {
            await _dbContext.CartProducts.AddAsync(cartProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateCartProduct(CartProduct cartProduct)
        {
            _dbContext.CartProducts.Update(cartProduct);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<CartProduct> GetCartProduct(CartProduct cartProduct)
        {
            var foundCartProduct = await _dbContext.CartProducts.FirstOrDefaultAsync(p => 
                p.CartId == cartProduct.CartId && p.ProductId == cartProduct.ProductId);
            
            return foundCartProduct;
        }

        public async Task<PaginatedList<CartProduct>> GetCartProductsPaginatedList(PaginationParameters paginationParams)
        {
            var cartProducts = await _dbContext.CartProducts
                .Skip((paginationParams.PageNumber - 1) * paginationParams.PageSize)
                .Take(paginationParams.PageSize).ToListAsync();
            
            var pagesCount = await _dbContext.CartProducts.CountAsync() / paginationParams.PageSize;

            var paginatedList = new PaginatedList<CartProduct>(cartProducts, paginationParams.PageNumber, pagesCount);
            return paginatedList;
        }

        public async Task DeleteCartProduct(CartProduct cartProductToDelete)
        {
            var foundProduct = await _dbContext.CartProducts
                .FirstOrDefaultAsync(p => p.CartId == cartProductToDelete.CartId
                                     && p.ProductId == cartProductToDelete.ProductId);

            _dbContext.CartProducts.Remove(foundProduct);
            await _dbContext.SaveChangesAsync();
        }
    }
}