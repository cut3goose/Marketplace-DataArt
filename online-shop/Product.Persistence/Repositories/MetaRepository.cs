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
    public class MetaRepository : BaseRepository<ProductDbContext, Meta>, IMetaRepository
    {
        public MetaRepository(ProductDbContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Meta>> GetMetaForProductAsync(int productId)
        {
            return await _dbContext.Metas
                .Where(m => m.ProductId == productId)
                .ToListAsync();
        }
    }
}
