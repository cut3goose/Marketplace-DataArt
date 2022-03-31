using System.Threading.Tasks;
using OnlineShop.Product.Domain.Models;

namespace OnlineShop.Product.Domain.Services.Interfaces
{
    public interface IMetaService
    {
        Task<MetaModel> CreateMetaAsync(MetaCreateModel metaCreateModel);
        Task<MetaListModel> GetMetaForProductAsync(int productId);
        Task<bool> UpdateMetaAsync(MetaUpdateModel metaUpdateModel);
        Task<bool> DeleteMetaAsync(int metaId);
    }
}
