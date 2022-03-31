using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;

namespace OnlineShop.Product.WebApi.ApiControllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class MetaController : ControllerBase
    {
        private readonly IMetaService _metaService;

        public MetaController(IMetaService metaService)
        {
            _metaService = metaService;
        }

        /// <summary>
        /// Gets the product's meta
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <response code="200">Returns the product's meta</response>
        [HttpGet("product/{productId:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<MetaListModel>> GetMetaForProduct(int productId)
        {
            var metaListModel = await _metaService.GetMetaForProductAsync(productId);

            return Ok(metaListModel);
        }

        /// <summary>
        /// Creates a meta
        /// </summary>
        /// <param name="metaCreateModel">The model to create a meta</param>
        /// <response code="200">Returns the newly created meta</response>
        /// <response code="400">The model is not valid</response>
        [HttpPost]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateMeta([FromBody] MetaCreateModel metaCreateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var meta = await _metaService.CreateMetaAsync(metaCreateModel);

            return Ok(meta);
        }

        /// <summary>
        /// Updates the meta
        /// </summary>
        /// <param name="metaUpdateModel">The model to update the meta</param>
        /// <response code="204">Updates the meta</response>
        /// <response code="400">The model is not valid</response>
        /// <response code="404">The specified meta is not found</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateMeta([FromBody] MetaUpdateModel metaUpdateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _metaService.UpdateMetaAsync(metaUpdateModel);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        /// <summary>
        /// Deletes the meta
        /// </summary>
        /// <param name="metaId">Id of the meta</param>
        /// <response code="204">Deletes the meta</response>
        /// <response code="404">The specified meta is not found</response>
        [HttpDelete("{metaId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteMeta(int metaId)
        {
            var result = await _metaService.DeleteMetaAsync(metaId);

            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
