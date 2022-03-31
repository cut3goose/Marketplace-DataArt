using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Infrastructure.DataAccess;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Order.Persistence.Context;
using OnlineShop.Order.Persistence.Repository.Interfaces;
using ProductsOrder = OnlineShop.Order.Persistence.Entities.Order;

namespace OnlineShop.Order.Persistence.Repository
{
    public class OrderRepository : BaseRepository<OrderDbContext, ProductsOrder>, IOrderRepository
    {
        public OrderRepository(OrderDbContext dbContext) : base(dbContext)
        {
        }
        
        public async Task CreateOrder(ProductsOrder order)
        {
            await _dbContext.AddAsync(order);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<PaginatedList<ProductsOrder>> GetAllOrdersByUser(string userId, PaginationParameters paginationParams)
        {
            var foundOrders = await _dbContext.Orders.Where(o => o.UserId == userId)
                    .Skip(paginationParams.PageNumber * paginationParams.PageSize - 1)
                    .Take(paginationParams.PageSize).ToListAsync();
            
            var pagesCount = await _dbContext.Orders.CountAsync() / paginationParams.PageSize;

            var paginatedList = new PaginatedList<ProductsOrder>(foundOrders, paginationParams.PageNumber, pagesCount);
            return paginatedList;
        }
    }
}