using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Contracts.Product.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Product.Domain.Services.Interfaces;

namespace OnlineShop.Product.WebApi.ApiControllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ReviewsController : ControllerBase
    {
        private readonly IReviewService _reviewService;

        public ReviewsController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        /// <summary>
        /// Gets the review
        /// </summary>
        /// <param name="reviewId">Id of the review</param>
        /// <response code="200">Returns the review</response>
        /// <response code="404">The specified review is not found</response>
        [HttpGet("{reviewId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ReviewModel>> GetReview(int reviewId)
        {
            var reviewModel = await _reviewService.GetReviewAsync(reviewId);

            if (reviewModel != null)
                return Ok(reviewModel);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets the product's reviews
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <param name="paginationParameters">Parameters for pagination</param>
        /// <response code="200">Returns the paginated list of the reviews</response>
        [HttpGet("product/{productId:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ReviewModel>> GetReviewsByProduct(
            int productId, [FromQuery] PaginationParameters paginationParameters)
        {
            var reviews = await _reviewService.GetReviewsByProductAsync(productId, paginationParameters);

            return Ok(reviews);
        }

        /// <summary>
        /// Creates a review
        /// </summary>
        /// <param name="reviewCreateModel">The model to create a review</param>
        /// <response code="201">Returns the newly created review and its URI</response>
        /// <response code="400">The model is not valid</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateReview([FromBody] ReviewCreateModel reviewCreateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var reviewModel = await _reviewService.CreateReviewAsync(reviewCreateModel);

            return Created($"api/reviews/{reviewModel.Id}", reviewModel);
        }

        /// <summary>
        /// Rates the review
        /// </summary>
        /// <param name="reviewRatingModel">The model to rate the review</param>
        /// <response code="204">Rates the review</response>
        [HttpPost("rate")]
        [ProducesResponseType(204)]
        public async Task<ActionResult> RateReview([FromBody] ReviewRatingModel reviewRatingModel)
        {
            await _reviewService.RateReviewAsync(reviewRatingModel);

            return NoContent();
        }

        /// <summary>
        /// Updates the review
        /// </summary>
        /// <param name="reviewUpdateModel">The model to update the review</param>
        /// <response code="204">Updates the review</response>
        /// <response code="400">The model is not valid</response>
        /// <response code="404">The specified review is not found</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateReview([FromBody] ReviewUpdateModel reviewUpdateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _reviewService.UpdateReviewAsync(reviewUpdateModel);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        /// <summary>
        /// Deletes the review
        /// </summary>
        /// <param name="reviewId">Id of the review</param>
        /// <response code="204">Deletes the review</response>
        /// <response code="404">The specified review is not found</response>
        [HttpDelete("{reviewId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteReview(int reviewId)
        {
            var result = await _reviewService.DeleteReviewAsync(reviewId);

            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
