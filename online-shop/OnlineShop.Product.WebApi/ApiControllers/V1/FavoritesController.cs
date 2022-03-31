using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Contracts.Product.Models;
using OnlineShop.Infrastructure.UserIdAccess.Interfaces;
using OnlineShop.Product.Domain.Services.Interfaces;

namespace OnlineShop.Product.WebApi.ApiControllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class FavoritesController : ControllerBase
    {
        private readonly IFavoriteService _favoriteService;
        private readonly IUserIdService _userIdService;

        public FavoritesController(IFavoriteService favoriteService, IUserIdService userIdService)
        {
            _favoriteService = favoriteService;
            _userIdService = userIdService;
        }

        /// <summary>
        /// Gets the favorites of the current user
        /// </summary>
        /// <response code="200">Returns the current user's favorites</response>
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<FavoriteListModel>> GetFavoritesByUser()
        {
            var userId = _userIdService.GetUserId();

            var favoriteListModel = await _favoriteService.GetFavoritesByUserAsync(userId);

            return Ok(favoriteListModel);
        }

        /// <summary>
        /// Creates a favorite
        /// </summary>
        /// <param name="favoriteCreateModel">The model to create a favorite</param>
        /// <response code="200">Returns the newly created favorite</response>
        /// <response code="400">The model is not valid</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<FavoriteModel>> CreateFavorite([FromBody] FavoriteCreateModel favoriteCreateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var favoriteModel = await _favoriteService.CreateFavoriteAsync(favoriteCreateModel);

            return Ok(favoriteModel);
        }

        /// <summary>
        /// Deletes the favorite
        /// </summary>
        /// <param name="favoriteDeleteModel">The model to delete the favorite</param>
        /// <response code="204">Deletes the favorite</response>
        /// <response code="404">The specified favorite is not found</response>
        [HttpDelete]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteFavorite([FromBody] FavoriteDeleteModel favoriteDeleteModel)
        {
            var result = await _favoriteService.DeleteFavoriteAsync(favoriteDeleteModel);

            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
