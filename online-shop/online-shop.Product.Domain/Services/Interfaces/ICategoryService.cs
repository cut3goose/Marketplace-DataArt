using System.Threading.Tasks;
using OnlineShop.Product.Domain.Models;

namespace OnlineShop.Product.Domain.Services.Interfaces
{
    public interface ICategoryService
    {
        Task<CategoryModel> CreateCategoryAsync(CategoryCreateModel categoryCreateModel);
        Task<CategoryModel> GetCategoryAsync(int categoryId);
        Task<CategoryListModel> GetCategoriesByProductAsync(int productId);
        Task<CategoryListModel> GetSubCategoriesByCategoryAsync(int categoryId, bool allChildren = false);
        Task<CategoryListModel> GetParentCategoriesByCategoryAsync(int categoryId);
        Task<CategoryListModel> GetMainCategoriesAsync();
        Task<bool> UpdateCategoryAsync(CategoryUpdateModel categoryUpdateModel);
        Task<bool> DeleteCategoryAsync(int categoryId);
    }
}
