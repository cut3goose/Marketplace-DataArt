using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.DataAccess.Interfaces;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Repositories.Interfaces
{
    public interface IReviewRatingRepository : IBaseRepository<ProductDbContext, ReviewRating>
    {
        Task<IEnumerable<ReviewRating>> GetReviewRatingsByReviewAsync(int reviewId);
    }
}
