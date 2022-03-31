using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.DataAccess.Interfaces;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Repositories.Interfaces
{
    public interface IFavoriteRepository : IBaseRepository<ProductDbContext, Favorite>
    {
        Task<Favorite> GetFavoriteAsync(int productId, string userId);
        Task<IEnumerable<Favorite>> GetFavoritesByUserAsync(string userId);
    }
}
