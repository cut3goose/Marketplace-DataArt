using OnlineShop.Contracts.Product.Enums;
using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Product.Persistence.Entities
{
    public class ReviewRating : AuditableEntity, IBaseEntity
    {
        public int ReviewId { get; set; }
        public Review Review { get; set; }
        public string UserId { get; set; }
        public Opinion Opinion { get; set; }
    }
}
