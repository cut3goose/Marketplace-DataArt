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
    public class TagRepository : BaseRepository<ProductDbContext, Tag>, ITagRepository
    {
        public TagRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Tag>> GetTagsByProductAsync(int productId)
        {
            return await _dbContext.ProductTags
                .Where(pt => pt.ProductId == productId)
                .Select(pt => pt.Tag)
                .ToListAsync();
        }
    }
}
