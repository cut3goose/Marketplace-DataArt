using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Contracts.Product.Models;
using OnlineShop.Product.Domain.Services.Interfaces;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Domain.Services
{
    public class FavoriteService : IFavoriteService
    {
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IMapper _mapper;

        public FavoriteService(IFavoriteRepository favoriteRepository, IMapper mapper)
        {
            _favoriteRepository = favoriteRepository;
            _mapper = mapper;
        }

        public async Task<FavoriteModel> CreateFavoriteAsync(FavoriteCreateModel favoriteCreateModel)
        {
            var favorite = _mapper.Map<Favorite>(favoriteCreateModel);

            await _favoriteRepository.AddAsync(favorite);

            return _mapper.Map<FavoriteModel>(favorite);
        }

        public async Task<FavoriteListModel> GetFavoritesByUserAsync(string userId)
        {
            var favorites = await _favoriteRepository.GetFavoritesByUserAsync(userId);

            return new FavoriteListModel
            {
                Favorites = _mapper.Map<IEnumerable<FavoriteModel>>(favorites)
            };
        }

        public async Task<bool> DeleteFavoriteAsync(FavoriteDeleteModel favoriteDeleteModel)
        {
            var favorite = await _favoriteRepository.GetFavoriteAsync(favoriteDeleteModel.ProductId, favoriteDeleteModel.UserId);

            if (favorite == null)
                return false;

            await _favoriteRepository.DeleteAsync(favorite);

            return true;
        }
    }
}
