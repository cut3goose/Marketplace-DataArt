using System.Threading.Tasks;
using OnlineShop.Contracts.Product.Models;

namespace OnlineShop.Product.Domain.Services.Interfaces
{
    public interface IFavoriteService
    {
        Task<FavoriteModel> CreateFavoriteAsync(FavoriteCreateModel favoriteCreateModel);
        Task<FavoriteListModel> GetFavoritesByUserAsync(string userId);
        Task<bool> DeleteFavoriteAsync(FavoriteDeleteModel favoriteDeleteModel);
    }
}
