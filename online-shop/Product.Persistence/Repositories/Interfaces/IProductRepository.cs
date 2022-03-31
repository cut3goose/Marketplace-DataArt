using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.DataAccess.Interfaces;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Product.Persistence.Context;

namespace OnlineShop.Product.Persistence.Repositories.Interfaces
{
    public interface IProductRepository : IBaseRepository<ProductDbContext, Entities.Product>
    {
        Task<PaginatedList<Entities.Product>> GetProductsByCategoryAsync(int categoryId, PaginationParameters paginationParameters);
        Task<IEnumerable<Entities.Product>> GetProductsByTagsAsync(int[] tagIds);
        Task<PaginatedList<Entities.Product>> SearchForProducts(string query, PaginationParameters paginationParameters);
        Task<IEnumerable<Entities.Product>> GetTopProductsAsync(int quantity);
    }
}
