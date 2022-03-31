using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.DataAccess;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Persistence.Repositories
{
    public class ReviewRepository : BaseRepository<ProductDbContext, Review>, IReviewRepository
    {
        public ReviewRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<PaginatedList<Review>> GetReviewsByProductAsync(int productId, PaginationParameters paginationParameters)
        {
            var reviews = await _dbContext.Reviews
                .Where(r => r.ProductId == productId)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .Include(r => r.ReviewRatings)
                .ToListAsync();

            var count = await _dbContext.Reviews
                .Where(r => r.ProductId == productId)
                .CountAsync();

            return new PaginatedList<Review>(
                reviews,
                paginationParameters.PageNumber,
                (int)Math.Ceiling(count / (double)paginationParameters.PageSize));
        }

        public async Task RateReviewAsync(ReviewRating rating)
        {
            await _dbContext.ReviewRatings.AddAsync(rating);
        }
    }
}
