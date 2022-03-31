using System.Threading.Tasks;
using OnlineShop.Product.Domain.Models;

namespace OnlineShop.Product.Domain.Services.Interfaces
{
    public interface IPhotoService
    {
        Task<PhotoListModel> AddPhotoAsync(PhotoCreateModel photoCreateModel);
        Task<PhotoModel> GetPhotoAsync(int photoId);
        Task<byte[]> GetPhotoFileAsync(int photoId);
        Task<PhotoListModel> GetPhotosByProductAsync(int productId);
        Task<PhotoModel> GetPhotoByCategoryAsync(int categoryId);
        Task<bool> SetPhotosForProductAsync(int productId, int[] photoIds);
        Task<bool> SetPhotoForCategoryAsync(int categoryId, int photoId);
        Task<bool> UpdatePhotoAsync(PhotoUpdateModel photoUpdateModel);
        Task<bool> DeletePhotoAsync(int photoId);
    }
}
