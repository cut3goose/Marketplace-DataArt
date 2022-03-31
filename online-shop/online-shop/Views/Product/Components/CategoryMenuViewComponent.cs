using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Product.Domain.Services.Interfaces;

namespace OnlineShop.Views.Product.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly ICategoryService _categoryService;

        public CategoryMenuViewComponent(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = (await _categoryService.GetMainCategoriesAsync()).Categories;
            return View("~/Views/Product/Components/_CategoryMenu.cshtml", categories);
        }
    }
}
