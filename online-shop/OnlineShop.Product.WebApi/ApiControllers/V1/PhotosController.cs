using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;

namespace OnlineShop.Product.WebApi.ApiControllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class PhotosController : ControllerBase
    {
        private readonly IPhotoService _photoService;

        public PhotosController(IPhotoService photoService)
        {
            _photoService = photoService;
        }

        /// <summary>
        /// Gets the photo by its Id
        /// </summary>
        /// <param name="photoId">Id of the photo</param>
        /// <response code="200">Returns the photo</response>
        /// <response code="404">The specified photo is not found</response>
        [HttpGet("{photoId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PhotoModel>> GetPhoto(int photoId)
        {
            var photoModel = await _photoService.GetPhotoAsync(photoId);

            if (photoModel != null)
                return Ok(photoModel);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets the photo file by its Id
        /// </summary>
        /// <param name="photoId">Id og the photo</param>
        /// <response code="200">Returns the photo file</response>
        /// <response code="404">The specified photo is not found</response>
        [HttpGet("{photoId:int}.png")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> GetPhotoFile(int photoId)
        {
            var photoFile = await _photoService.GetPhotoFileAsync(photoId);

            if (photoFile != null)
                return File(photoFile, "image/png");
            else
                return NotFound();
        }

        /// <summary>
        /// Gets the product's photos
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <response code="200">Returns the product's photos</response>
        [HttpGet("product/{productId:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PhotoListModel>> GetPhotosByProduct(int productId)
        {
            var photoListModel = await _photoService.GetPhotosByProductAsync(productId);

            return Ok(photoListModel);
        }

        /// <summary>
        /// Gets the category's photo
        /// </summary>
        /// <param name="categoryId">Id of the category</param>
        /// <response code="200">Returns the category's photo</response>
        /// <response code="404">The specified category has no photos</response>
        [HttpGet("category/{categoryId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<PhotoModel>> GetPhotoByCategory(int categoryId)
        {
            var photoModel = await _photoService.GetPhotoByCategoryAsync(categoryId);

            if (photoModel != null)
                return Ok(photoModel);
            else
                return NotFound();
        }

        /// <summary>
        /// Adds a photo
        /// </summary>
        /// <param name="photoCreateModel">The model to create a photo</param>
        /// <response code="200">Returns the newly created photo in different sizes</response>
        /// <response code="400">The model is not valid</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<PhotoListModel>> AddPhoto([FromForm] PhotoCreateModel photoCreateModel)
        {
            var photoListModel = await _photoService.AddPhotoAsync(photoCreateModel);

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(photoListModel);
        }

        /// <summary>
        /// Sets the product's photos
        /// </summary>
        /// <param name="productPhotosSetModel">The model to set the product's photos</param>
        /// <response code="204">Sets the product's photos</response>
        /// <response code="404">The specified photos are not found</response>
        [HttpPost("product")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> SetPhotosForProduct(ProductPhotosSetModel productPhotosSetModel)
        {
            var productId = productPhotosSetModel.ProductId;
            var photoIds = productPhotosSetModel.PhotoIds.ToArray();

            var result = await _photoService.SetPhotosForProductAsync(productId, photoIds);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        /// <summary>
        /// Sets the category's photo
        /// </summary>
        /// <param name="categoryPhotoSetModel">The model to set the category's photo</param>
        /// <response code="204">Sets the category's photo</response>
        /// <response code="404">The specified photo is not found</response>
        [HttpPost("category")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> SetPhotoForCategory(CategoryPhotoSetModel categoryPhotoSetModel)
        {
            var categoryId = categoryPhotoSetModel.CategoryId;
            var photoId = categoryPhotoSetModel.PhotoId;

            var result = await _photoService.SetPhotoForCategoryAsync(categoryId, photoId);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        /// <summary>
        /// Updates the photo
        /// </summary>
        /// <param name="photoUpdateModel">The model to update the photo</param>
        /// <response code="204">Updates the photo</response>
        /// <response code="400">The model is not valid</response>
        /// <response code="404">The specified photo is not found</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdatePhoto([FromBody] PhotoUpdateModel photoUpdateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _photoService.UpdatePhotoAsync(photoUpdateModel);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        /// <summary>
        /// Deletes the photo
        /// </summary>
        /// <param name="photoId">Id of the photo</param>
        /// <response code="204">Deletes the photo</response>
        /// <response code="404">The specified photo is not found</response>
        [HttpDelete("{photoId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeletePhoto(int photoId)
        {
            var result = await _photoService.DeletePhotoAsync(photoId);

            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
