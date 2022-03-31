using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Contracts.Product.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Product.Domain.Services.Interfaces;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Domain.Services
{
    public class ReviewService : IReviewService
    {
        private readonly IReviewRepository _reviewRepository;
        private readonly IMapper _mapper;

        public ReviewService(IReviewRepository reviewRepository, IMapper mapper)
        {
            _reviewRepository = reviewRepository;
            _mapper = mapper;
        }

        public async Task<ReviewModel> CreateReviewAsync(ReviewCreateModel reviewCreateModel)
        {
            var review = _mapper.Map<Review>(reviewCreateModel);

            await _reviewRepository.AddAsync(review);

            return _mapper.Map<ReviewModel>(review);
        }

        public async Task<ReviewModel> GetReviewAsync(int reviewId)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);

            if (review == null)
                return null;

            return _mapper.Map<ReviewModel>(review);
        }

        public async Task<PaginatedList<ReviewModel>> GetReviewsByProductAsync(int productId, PaginationParameters paginationParameters)
        {
            var reviewsPaginatedList = await _reviewRepository.GetReviewsByProductAsync(productId, paginationParameters);

            return new PaginatedList<ReviewModel>(
                _mapper.Map<IEnumerable<ReviewModel>>(reviewsPaginatedList.PageData),
                reviewsPaginatedList.PageNumber,
                reviewsPaginatedList.PagesCount);
        }

        public async Task RateReviewAsync(ReviewRatingModel reviewRatingModel)
        {
            var reviewRating = _mapper.Map<ReviewRating>(reviewRatingModel);

            await _reviewRepository.RateReviewAsync(reviewRating);
        }

        public async Task<bool> UpdateReviewAsync(ReviewUpdateModel reviewUpdateModel)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewUpdateModel.Id);

            if (review == null)
                return false;

            _mapper.Map(reviewUpdateModel, review);
            await _reviewRepository.UpdateAsync(review);

            return true;
        }

        public async Task<bool> DeleteReviewAsync(int reviewId)
        {
            var review = await _reviewRepository.GetByIdAsync(reviewId);

            if (review == null)
                return false;

            await _reviewRepository.DeleteAsync(review);

            return true;
        }
    }
}
