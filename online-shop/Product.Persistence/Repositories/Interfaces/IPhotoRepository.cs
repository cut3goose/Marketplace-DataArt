using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.DataAccess.Interfaces;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Repositories.Interfaces
{
    public interface IPhotoRepository : IBaseRepository<ProductDbContext, Photo>
    {
        Task<IEnumerable<Photo>> AddPhotosAsync(IEnumerable<Photo> photos);
        Task<IEnumerable<Photo>> GetPhotosByProductAsync(int productId);
        Task<Photo> GetPhotoByCategoryAsync(int categoryId);
        Task SetPhotosForProductAsync(int productId, int[] photoIds);
        Task SetPhotoForCategoryAsync(int categoryId, int photoId);
    }
}
