using OnlineShop.Infrastructure.AuditableEntity;

namespace OnlineShop.Product.Persistence.Entities
{
    public class ProductPhoto : AuditableEntity
    {
        public int PhotoId { get; set; }
        public Photo Photo { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
