using OnlineShop.Infrastructure.AuditableEntity;

namespace OnlineShop.Order.Persistence.Entities
{
    public class OrderProduct : AuditableEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int ProductId { get; set; }
        public decimal Price { get; set; }
        public float? Discount { get; set; }
        public int Quantity { get; set; }
    }
}
