using OnlineShop.Contracts.Product.Enums;
using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Product.Persistence.Entities
{
    public class Photo : AuditableEntity, IBaseEntity
    {
        public int Id { get; set; }
        public PhotoSize Size { get; set; }
        public byte[] File { get; set; }
    }
}
