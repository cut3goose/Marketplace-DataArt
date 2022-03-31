using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Product.Persistence.Entities
{
    public class Favorite : AuditableEntity, IBaseEntity
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
    }
}
