using System.Threading.Tasks;
using OnlineShop.Infrastructure.Models.PaginatedList;
using ProductsOrder = OnlineShop.Order.Persistence.Entities.Order;

namespace OnlineShop.Order.Persistence.Repository.Interfaces
{
    public interface IOrderRepository
    {
        public Task CreateOrder(ProductsOrder order);
        public Task<PaginatedList<ProductsOrder>> GetAllOrdersByUser(string userId, PaginationParameters paginationParameters);
    }
}