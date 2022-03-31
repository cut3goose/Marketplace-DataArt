using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Contracts.Product.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Domain.Services.Interfaces;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Domain.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<ProductModel> CreateProductAsync(ProductCreateModel productCreateModel)
        {
            var product = _mapper.Map<Persistence.Entities.Product>(productCreateModel);

            await _productRepository.AddAsync(product);

            return _mapper.Map<ProductModel>(product);
        }

        public async Task<ProductModel> GetProductAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null)
                return null;

            return _mapper.Map<ProductModel>(product);
        }

        public async Task<PaginatedList<ProductModel>> GetProductsByCategoryAsync(int categoryId, PaginationParameters paginationParameters)
        {
            var productsPaginatedList = await _productRepository.GetProductsByCategoryAsync(categoryId, paginationParameters);

            return new PaginatedList<ProductModel>(
                _mapper.Map<IEnumerable<ProductModel>>(productsPaginatedList.PageData),
                productsPaginatedList.PageNumber,
                productsPaginatedList.PagesCount);
        }

        public async Task<ProductListModel> GetProductsByTagsAsync(TagListModel tagListModel)
        {
            var tagIds = tagListModel.Tags
                .Select(t => t.Id)
                .ToArray();

            var products = await _productRepository.GetProductsByTagsAsync(tagIds);

            var productListModel = new ProductListModel
            {
                Products = _mapper.Map<IEnumerable<ProductModel>>(products)
            };

            return productListModel;
        }

        public async Task<PaginatedList<ProductModel>> SearchForProducts(string query, PaginationParameters paginationParameters)
        {
            if (string.IsNullOrWhiteSpace(query))
                return null;

            var productsPaginatedList = await _productRepository.SearchForProducts(query, paginationParameters);

            return new PaginatedList<ProductModel>(
                _mapper.Map<IEnumerable<ProductModel>>(productsPaginatedList.PageData),
                productsPaginatedList.PageNumber,
                productsPaginatedList.PagesCount);
        }

        public async Task<ProductListModel> GetTopProductsAsync(int quantity)
        {
            var products = await _productRepository.GetTopProductsAsync(quantity);

            var productListModel = new ProductListModel
            {
                Products = _mapper.Map<IEnumerable<ProductModel>>(products)
            };

            return productListModel;
        }

        public async Task<bool> UpdateProductAsync(ProductUpdateModel productUpdateModel)
        {
            var product = await _productRepository.GetByIdAsync(productUpdateModel.Id);

            if (product == null)
                return false;

            _mapper.Map(productUpdateModel, product);
            await _productRepository.UpdateAsync(product);

            return true;
        }

        public async Task<bool> DeleteProductAsync(int productId)
        {
            var product = await _productRepository.GetByIdAsync(productId);

            if (product == null)
                return false;

            await _productRepository.DeleteAsync(product);

            return true;
        }
    }
}
