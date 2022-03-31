using System.Threading.Tasks;
using OnlineShop.Infrastructure.DataAccess.Interfaces;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Repositories.Interfaces
{
    public interface IReviewRepository : IBaseRepository<ProductDbContext, Review>
    {
        Task<PaginatedList<Review>> GetReviewsByProductAsync(int productId, PaginationParameters paginationParameters);
        Task RateReviewAsync(ReviewRating rating);
    }
}
