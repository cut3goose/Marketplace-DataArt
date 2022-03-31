using System.Collections.Generic;
using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Cart.Persistence.Entities
{
    public class Cart : AuditableEntity, IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
    }
}
