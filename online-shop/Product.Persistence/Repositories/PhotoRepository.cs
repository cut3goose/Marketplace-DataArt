using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.DataAccess;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Persistence.Repositories
{
    public class PhotoRepository : BaseRepository<ProductDbContext, Photo>, IPhotoRepository
    {
        public PhotoRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Photo>> AddPhotosAsync(IEnumerable<Photo> photos)
        {
            await _dbContext.Photos.AddRangeAsync(photos);
            await _dbContext.SaveChangesAsync();

            return photos;
        }

        public async Task<IEnumerable<Photo>> GetPhotosByProductAsync(int productId)
        {
            return await _dbContext.ProductPhotos
                .Where(pf => pf.ProductId == productId)
                .Select(pf => pf.Photo)
                .ToListAsync();
        }

        public async Task<Photo> GetPhotoByCategoryAsync(int categoryId)
        {
            return await _dbContext.Categories
                .Where(c => c.Id == categoryId)
                .Select(c => c.Photo)
                .SingleOrDefaultAsync();
        }

        public async Task SetPhotosForProductAsync(int productId, int[] photoIds)
        {
            foreach (var photoId in photoIds)
            {
                var productPhoto = new ProductPhoto
                {
                    ProductId = productId,
                    PhotoId = photoId
                };

                await _dbContext.ProductPhotos.AddAsync(productPhoto);
            }

            await _dbContext.SaveChangesAsync();
        }

        public async Task SetPhotoForCategoryAsync(int categoryId, int photoId)
        {
            var category = await _dbContext.Categories
                .Where(c => c.Id == categoryId)
                .SingleOrDefaultAsync();

            category.PhotoId = photoId;
            _dbContext.Entry(category).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }
}
