using System.Threading.Tasks;
using OnlineShop.Product.Domain.Models;

namespace OnlineShop.Product.Domain.Services.Interfaces
{
    public interface ITagService
    {
        Task<TagModel> CreateTagAsync(TagCreateModel tagCreateModel);
        Task<TagListModel> GetTagsByProductAsync(int productId);
        Task<bool> UpdateTagAsync(TagUpdateModel tagUpdateModel);
        Task<bool> DeleteTagAsync(int tagId);
    }
}
