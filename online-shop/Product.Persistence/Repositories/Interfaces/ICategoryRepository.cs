using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.DataAccess.Interfaces;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Repositories.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<ProductDbContext, Category>
    {
        Task<IEnumerable<Category>> GetCategoriesByProductAsync(int productId);
        Task<IEnumerable<Category>> GetSubCategoriesByCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetParentCategoriesByCategoryAsync(int categoryId);
        Task<IEnumerable<Category>> GetMainCategoriesAsync();
    }
}
