using System.Threading.Tasks;
using OnlineShop.Contracts.Product.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;

namespace OnlineShop.Product.Domain.Services.Interfaces
{
    public interface IReviewService
    {
        Task<ReviewModel> CreateReviewAsync(ReviewCreateModel reviewCreateModel);
        Task<ReviewModel> GetReviewAsync(int reviewId);
        Task<PaginatedList<ReviewModel>> GetReviewsByProductAsync(int productId, PaginationParameters paginationParameters);
        Task RateReviewAsync(ReviewRatingModel reviewRatingModel);
        Task<bool> UpdateReviewAsync(ReviewUpdateModel reviewUpdateModel);
        Task<bool> DeleteReviewAsync(int reviewId);
    }
}
