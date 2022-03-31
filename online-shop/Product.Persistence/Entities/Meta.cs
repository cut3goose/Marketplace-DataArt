using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Product.Persistence.Entities
{
    public class Meta : AuditableEntity, IBaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
