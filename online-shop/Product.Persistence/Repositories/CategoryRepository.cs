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
    public class CategoryRepository : BaseRepository<ProductDbContext, Category>, ICategoryRepository
    {
        public CategoryRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Category>> GetCategoriesByProductAsync(int productId)
        {
            var categories = new List<Category>();

            var category = await _dbContext.Products
                .Where(p => p.Id == productId)
                .Select(p => p.Category)
                .SingleOrDefaultAsync();
            categories.Add(category);

            var parentCategories = await GetParentCategoriesByCategoryAsync(category.Id);
            categories.AddRange(parentCategories);

            return categories;
        }

        public async Task<IEnumerable<Category>> GetSubCategoriesByCategoryAsync(int categoryId)
        {
            return await _dbContext.Categories
                .Where(c => c.ParentCategoryId == categoryId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Category>> GetParentCategoriesByCategoryAsync(int categoryId)
        {
            var categories = new List<Category>();

            var parentCategory = await GetFirstParentCategoryByCategory(categoryId);

            while (parentCategory != null)
            {
                categories.Add(parentCategory);
                parentCategory = await GetFirstParentCategoryByCategory(parentCategory.Id);
            }

            return categories;
        }

        private async Task<Category> GetFirstParentCategoryByCategory(int categoryId)
        {
            return await _dbContext.Categories
                .Where(c => c.Id == categoryId && c.ParentCategoryId != null)
                .Select(c => c.ParentCategory)
                .SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Category>> GetMainCategoriesAsync()
        {
            return await _dbContext.Categories
                .Where(c => c.ParentCategoryId == null)
                .ToListAsync();
        }
    }
}
