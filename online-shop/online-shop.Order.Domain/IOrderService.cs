using System.Threading.Tasks;
using OnlineShop.Contracts.Order.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;

namespace OnlineShop.Order.Domain
{
    public interface IOrderService
    {
        public Task CreateOrder(OrderCreateModel orderCreateModel);
        public Task<PaginatedList<OrderModel>> GetAllOrdersByUser(PaginationParameters paginationParameters);
    }
}