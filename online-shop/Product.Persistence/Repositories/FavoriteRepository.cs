using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.DataAccess;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Persistence.Repositories
{
    public class FavoriteRepository : BaseRepository<ProductDbContext, Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<Favorite> GetFavoriteAsync(int productId, string userId)
        {
            return await _dbContext.Favorites.FindAsync(productId, userId);
        }

        public async Task<IEnumerable<Favorite>> GetFavoritesByUserAsync(string userId)
        {
            return await _dbContext.Favorites
                .Where(f => f.UserId == userId)
                .ToListAsync();
        }
    }
}
