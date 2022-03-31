using OnlineShop.Infrastructure.AuditableEntity;

namespace OnlineShop.Product.Persistence.Entities
{
    public class ProductTag : AuditableEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int TagId { get; set; }
        public Tag Tag { get; set; }
    }
}
