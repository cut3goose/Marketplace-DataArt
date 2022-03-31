using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;

namespace OnlineShop.Product.WebApi.ApiControllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class TagsController : ControllerBase
    {
        private readonly ITagService _tagService;

        public TagsController(ITagService tagService)
        {
            _tagService = tagService;
        }

        /// <summary>
        /// Gets the product's tags
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <response code="200">Returns the product's tags</response>
        [HttpGet("product/{productId:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<TagListModel>> GetTagsByProduct(int productId)
        {
            var tags = await _tagService.GetTagsByProductAsync(productId);

            return Ok(tags);
        }

        /// <summary>
        /// Creates a tag
        /// </summary>
        /// <param name="tagCreateModel">The model to create a tag</param>
        /// <response code="200">Creates a tag</response>
        /// <response code="400">The model is not valid</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult<TagModel>> CreateTag([FromBody] TagCreateModel tagCreateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var tagModel = await _tagService.CreateTagAsync(tagCreateModel);

            return Ok(tagModel);
        }

        /// <summary>
        /// Updates the tag
        /// </summary>
        /// <param name="tagUpdateModel">The model to update the tag</param>
        /// <response code="204">Updates the tag</response>
        /// <response code="400">The model is not valid</response>
        /// <response code="404">The specified tag is not found</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateTag([FromBody] TagUpdateModel tagUpdateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _tagService.UpdateTagAsync(tagUpdateModel);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        /// <summary>
        /// Deletes the tag
        /// </summary>
        /// <param name="tagId">Id of the tag</param>
        /// <response code="204">Deletes the tag</response>
        /// <response code="404">The specified tag is not found</response>
        [HttpDelete("{tagId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteTag(int tagId)
        {
            var result = await _tagService.DeleteTagAsync(tagId);

            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
