using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Contracts.Order.Enums;

namespace OnlineShop.Order.Persistence.Entities
{
    public class Transaction : AuditableEntity
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public string UserId { get; set; }
        public TransactionStatus Status { get; set; }
    }
}
