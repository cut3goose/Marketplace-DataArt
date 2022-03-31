using System.Threading.Tasks;
using OnlineShop.Contracts.Product.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Product.Domain.Models;

namespace OnlineShop.Product.Domain.Services.Interfaces
{
    public interface IProductService
    {
        Task<ProductModel> CreateProductAsync(ProductCreateModel productCreateModel);
        Task<ProductModel> GetProductAsync(int productId);
        Task<PaginatedList<ProductModel>> GetProductsByCategoryAsync(int categoryId, PaginationParameters paginationParameters);
        Task<ProductListModel> GetProductsByTagsAsync(TagListModel tags);
        Task<PaginatedList<ProductModel>> SearchForProducts(string query, PaginationParameters paginationParameters);
        Task<ProductListModel> GetTopProductsAsync(int quantity);
        Task<bool> UpdateProductAsync(ProductUpdateModel productUpdateModel);
        Task<bool> DeleteProductAsync(int productId);
    }
}
