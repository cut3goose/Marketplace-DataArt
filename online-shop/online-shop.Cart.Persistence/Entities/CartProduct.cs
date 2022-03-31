using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Cart.Persistence.Entities
{
    public class CartProduct : AuditableEntity, IBaseEntity
    {
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
