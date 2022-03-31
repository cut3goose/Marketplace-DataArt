using System.Collections.Generic;
using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Product.Persistence.Entities
{
    public class Tag : AuditableEntity, IBaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
    }
}
