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
    public class ReviewRatingRepository : BaseRepository<ProductDbContext, ReviewRating>, IReviewRatingRepository
    {
        public ReviewRatingRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<ReviewRating>> GetReviewRatingsByReviewAsync(int reviewId)
        {
            return await _dbContext.ReviewRatings
                .Where(rr => rr.ReviewId == reviewId)
                .ToListAsync();
        }
    }
}
