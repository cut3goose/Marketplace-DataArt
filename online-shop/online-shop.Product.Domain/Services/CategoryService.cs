using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Domain.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        public async Task<CategoryModel> CreateCategoryAsync(CategoryCreateModel categoryCreateModel)
        {
            var category = _mapper.Map<Category>(categoryCreateModel);

            await _categoryRepository.AddAsync(category);

            return _mapper.Map<CategoryModel>(category);
        }

        public async Task<CategoryModel> GetCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
                return null;

            return _mapper.Map<CategoryModel>(category);
        }

        public async Task<CategoryListModel> GetCategoriesByProductAsync(int productId)
        {
            var categories = await _categoryRepository.GetCategoriesByProductAsync(productId);

            return CreateCategoryListModel(categories);
        }

        public async Task<CategoryListModel> GetSubCategoriesByCategoryAsync(int categoryId, bool allChildren = false)
        {
            var categories = await _categoryRepository.GetSubCategoriesByCategoryAsync(categoryId);

            var categoryListModel = CreateCategoryListModel(categories);

            if (allChildren)
            {
                foreach (var category in categoryListModel.Categories)
                {
                    category.SubCategories = (await GetSubCategoriesByCategoryAsync(category.Id, true)).Categories;
                }
            }

            return categoryListModel;
        }

        public async Task<CategoryListModel> GetParentCategoriesByCategoryAsync(int categoryId)
        {
            var categories = await _categoryRepository.GetParentCategoriesByCategoryAsync(categoryId);

            return CreateCategoryListModel(categories);
        }
        public async Task<CategoryListModel> GetMainCategoriesAsync()
        {
            var categories = await _categoryRepository.GetMainCategoriesAsync();

            var categoryListModel = CreateCategoryListModel(categories);

            foreach (var category in categoryListModel.Categories)
            {
                category.SubCategories = (await GetSubCategoriesByCategoryAsync(category.Id, true)).Categories;
            }

            return categoryListModel;
        }

        public async Task<bool> UpdateCategoryAsync(CategoryUpdateModel categoryUpdateModel)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryUpdateModel.Id);

            if (category == null)
                return false;

            _mapper.Map(categoryUpdateModel, category);
            await _categoryRepository.UpdateAsync(category);

            return true;
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await _categoryRepository.GetByIdAsync(categoryId);

            if (category == null)
                return false;

            await _categoryRepository.DeleteAsync(category);

            return true;
        }

        private CategoryListModel CreateCategoryListModel(IEnumerable<Category> categories)
        {
            return new CategoryListModel
            {
                Categories = _mapper.Map<IEnumerable<CategoryModel>>(categories)
            };
        }

    }
}
