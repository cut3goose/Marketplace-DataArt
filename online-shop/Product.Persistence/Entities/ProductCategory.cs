using OnlineShop.Infrastructure.AuditableEntity;

namespace OnlineShop.Product.Persistence.Entities
{
    public class ProductCategory : AuditableEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
