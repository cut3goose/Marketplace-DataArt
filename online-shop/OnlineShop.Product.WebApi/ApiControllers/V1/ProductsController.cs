using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Contracts.Product.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;

namespace OnlineShop.Product.WebApi.ApiControllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        /// <summary>
        /// Gets the product
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <response code="200">Returns the product</response>
        /// <response code="404">The specified product is not found</response>
        [HttpGet("{productId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<ProductModel>> GetProduct(int productId)
        {
            var productModel = await _productService.GetProductAsync(productId);

            if (productModel != null)
                return Ok(productModel);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets the products of the specified category
        /// </summary>
        /// <param name="categoryId">Id of the category</param>
        /// <param name="paginationParameters">Parameters for pagination</param>
        /// <response code="200">Returns the paginated list of the products</response>
        [HttpGet("category/{categoryId}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PaginatedList<ProductModel>>> GetProductsByCategory(
            int categoryId, [FromQuery] PaginationParameters paginationParameters)
        {
            var products = await _productService.GetProductsByCategoryAsync(categoryId, paginationParameters);

            return Ok(products);
        }

        /// <summary>
        /// Gets the products by tags
        /// </summary>
        /// <param name="tagListModel">The model of tags</param>
        /// <response code="200">Returns the products</response>
        [HttpGet("tags")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ProductListModel>> GetProductsByTags([FromBody] TagListModel tagListModel)
        {
            var products = await _productService.GetProductsByTagsAsync(tagListModel);

            return Ok(products);
        }

        /// <summary>
        /// Search for products
        /// </summary>
        /// <param name="query">Query term</param>
        /// <param name="paginationParameters">Parameters for pagination</param>
        /// <returns>List of products</returns>
        [HttpGet("search")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PaginatedList<ProductModel>>> SearchForProducts([FromQuery] string query,
            [FromQuery] PaginationParameters paginationParameters)
        {
            var products = await _productService.SearchForProducts(query, paginationParameters);

            return Ok(products);
        }

        /// <summary>
        /// Gets top products
        /// </summary>
        /// <param name="quantity">Number of products</param>
        /// <returns>Returns top products</returns>
        [HttpGet("top/{quantity}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<ProductListModel>> GetTopProducts(int quantity)
        {
            var products = await _productService.GetTopProductsAsync(quantity);

            return Ok(products);
        }

        /// <summary>
        /// Creates a product
        /// </summary>
        /// <param name="productCreateModel">The model to create a product</param>
        /// <response code="201">Returns the newly created product and its URI</response>
        /// <response code="400">The model is not valid</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateProduct([FromBody] ProductCreateModel productCreateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var productModel = await _productService.CreateProductAsync(productCreateModel);

            return Created($"api/products/{productModel.Id}", productModel);
        }

        /// <summary>
        /// Updates the product
        /// </summary>
        /// <param name="productUpdateModel">The model to update the product</param>
        /// <response code="204">Updates the product</response>
        /// <response code="400">The model is not valid</response>
        /// <response code="404">The specified product is not found</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductUpdateModel productUpdateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _productService.UpdateProductAsync(productUpdateModel);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        /// <summary>
        /// Deletes the product
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <response code="204">Deletes the product</response>
        /// <response code="404">The specified product is not found</response>
        [HttpDelete("{productId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteProduct(int productId)
        {
            var result = await _productService.DeleteProductAsync(productId);

            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
