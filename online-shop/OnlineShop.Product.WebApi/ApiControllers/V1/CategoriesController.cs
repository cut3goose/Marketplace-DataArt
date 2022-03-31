using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;

namespace OnlineShop.Product.WebApi.ApiControllers.V1
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiExplorerSettings(GroupName = "v1")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        /// <summary>
        /// Gets the category by Id
        /// </summary>
        /// <param name="categoryId">Id of the category</param>
        /// <response code="200">Returns the category</response>
        /// <response code="404">Unable to find category by this id</response>
        [HttpGet("{categoryId:int}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<CategoryModel>> GetCategory(int categoryId)
        {
            var categoryModel = await _categoryService.GetCategoryAsync(categoryId);

            if (categoryModel != null)
                return Ok(categoryModel);
            else
                return NotFound();
        }

        /// <summary>
        /// Gets the main categories
        /// </summary>
        /// <response code="200">Returns the main categories</response>
        [HttpGet("main")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CategoryListModel>> GetMainCategories()
        {
            var categories = await _categoryService.GetMainCategoriesAsync();

            return Ok(categories);
        }

        /// <summary>
        /// Gets categories by product
        /// </summary>
        /// <param name="productId">Id of the product</param>
        /// <response code="200">Returns the product's categories</response>
        [HttpGet("product/{productId:int}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CategoryListModel>> GetCategoriesByProduct(int productId)
        {
            var categories = await _categoryService.GetCategoriesByProductAsync(productId);

            return Ok(categories);
        }

        /// <summary>
        /// Gets subcategories of the specified category
        /// </summary>
        /// <param name="categoryId">Id of the category</param>
        /// <response code="200">Returns the subcategories</response>
        [HttpGet("{categoryId:int}/subCategories")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CategoryListModel>> GetSubCategoriesByCategory(int categoryId)
        {
            var categories = await _categoryService.GetSubCategoriesByCategoryAsync(categoryId);

            return Ok(categories);
        }

        /// <summary>
        /// Gets parent categories of the specified category
        /// </summary>
        /// <param name="categoryId">Id of the category</param>
        /// <response code="200">Returns the parent categories</response>
        [HttpGet("{categoryId:int}/parentCategories")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<CategoryListModel>> GetParentCategoriesByCategory(int categoryId)
        {
            var categories = await _categoryService.GetParentCategoriesByCategoryAsync(categoryId);

            return Ok(categories);
        }

        /// <summary>
        /// Creates a category
        /// </summary>
        /// <param name="categoryCreateModel">The model to create a category</param>
        /// <response code="201">Returns the newly created category and its URI</response>
        /// <response code="400">The model is not valid</response>
        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(400)]
        public async Task<ActionResult> CreateCategory([FromBody] CategoryCreateModel categoryCreateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var categoryModel = await _categoryService.CreateCategoryAsync(categoryCreateModel);

            return Created($"api/categories/{categoryModel.Id}", categoryModel);
        }

        /// <summary>
        /// Updates the category
        /// </summary>
        /// <param name="categoryUpdateModel">The model to update the category</param>
        /// <response code="204">Updates the category</response>
        /// <response code="400">The model is not valid</response>
        /// <response code="404">The specified category is not found</response>
        [HttpPut]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> UpdateCategory([FromBody] CategoryUpdateModel categoryUpdateModel)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _categoryService.UpdateCategoryAsync(categoryUpdateModel);

            if (result)
                return NoContent();
            else
                return NotFound();
        }

        /// <summary>
        /// Deletes the category
        /// </summary>
        /// <param name="categoryId">Id of the category</param>
        /// <response code="204">Deletes the category</response>
        /// <response code="404">The specified category is not found</response>
        [HttpDelete("{categoryId:int}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> DeleteCategory(int categoryId)
        {
            var result = await _categoryService.DeleteCategoryAsync(categoryId);

            if (result)
                return NoContent();
            else
                return NotFound();
        }
    }
}
