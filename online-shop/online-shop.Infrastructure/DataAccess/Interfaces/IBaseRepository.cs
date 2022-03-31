using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.Infrastructure.DataAccess.Interfaces
{
    public interface IBaseRepository<TContext, TEntity>
        where TContext : DbContext
        where TEntity : class, IBaseEntity
    {
        Task<TEntity> GetByIdAsync(int id);
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity> AddAsync(TEntity entity);
        Task UpdateAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}