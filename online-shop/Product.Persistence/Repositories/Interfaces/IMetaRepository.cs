using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineShop.Infrastructure.DataAccess.Interfaces;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Repositories.Interfaces
{
    public interface IMetaRepository : IBaseRepository<ProductDbContext, Meta>
    {
        Task<IEnumerable<Meta>> GetMetaForProductAsync(int productId);
    }
}
