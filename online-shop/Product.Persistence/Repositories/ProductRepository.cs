using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.DataAccess;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Persistence.Repositories
{
    public class ProductRepository : BaseRepository<ProductDbContext, Entities.Product>, IProductRepository
    {
        private readonly ICategoryRepository _categoryRepository;

        public ProductRepository(ProductDbContext dbContext, ICategoryRepository categoryRepository)
            : base(dbContext)
        {
            _categoryRepository = categoryRepository;
        }

        public override async Task<Entities.Product> AddAsync(Entities.Product product)
        {
            await _dbContext.Products.AddAsync(product);
            await _dbContext.SaveChangesAsync();

            var productId = product.Id;
            var categoryId = product.CategoryId;

            var productCategories = new List<ProductCategory>
            {
                new ProductCategory
                {
                    ProductId = productId,
                    CategoryId = categoryId
                }
            };

            var parentCategories = await _categoryRepository
                .GetParentCategoriesByCategoryAsync(categoryId);

            productCategories.AddRange(parentCategories.Select(c => new ProductCategory
            {
                ProductId = productId,
                CategoryId = c.Id
            }));

            await _dbContext.ProductCategories.AddRangeAsync(productCategories);
            await _dbContext.SaveChangesAsync();

            return product;
        }

        public async Task<PaginatedList<Entities.Product>> GetProductsByCategoryAsync(int categoryId, PaginationParameters paginationParameters)
        {
            var products = await _dbContext.ProductCategories
                .Where(pt => pt.CategoryId == categoryId)
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .Select(pt => pt.Product)
                .ToListAsync();

            var count = await _dbContext.ProductCategories
                .Where(pt => pt.CategoryId == categoryId)
                .CountAsync();

            return new PaginatedList<Entities.Product>(
                products,
                paginationParameters.PageNumber,
                (int)Math.Ceiling(count / (double)paginationParameters.PageSize));
        }

        public async Task<IEnumerable<Entities.Product>> GetProductsByTagsAsync(int[] tagIds)
        {
            return await _dbContext.ProductTags
                .Where(pt => tagIds.Contains(pt.TagId))
                .Select(pt => pt.Product)
                .ToListAsync();
        }

        public async Task<PaginatedList<Entities.Product>> SearchForProducts(string query, PaginationParameters paginationParameters)
        {
            var products = await _dbContext.Products
                .Where(p => p.Name.Contains(query))
                .Skip((paginationParameters.PageNumber - 1) * paginationParameters.PageSize)
                .Take(paginationParameters.PageSize)
                .ToListAsync();

            var count = await _dbContext.Products
                .Where(p => p.Name.Contains(query))
                .CountAsync();

            return new PaginatedList<Entities.Product>(
                products,
                paginationParameters.PageNumber,
                (int)Math.Ceiling(count / (double)paginationParameters.PageSize));
        }

        public async Task<IEnumerable<Entities.Product>> GetTopProductsAsync(int quantity)
        {
            var productsCount = await _dbContext.Products
                .CountAsync();

            if (quantity > productsCount)
            {
                quantity = productsCount;
            }

            var topProducts = _dbContext.Products
                .Take(quantity)
                .ToList();

            return topProducts;
        }
    }
}
