using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Product.Persistence.Entities
{
    public class Category : AuditableEntity, IBaseEntity
    {
        public int Id { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public string Name { get; set; }
        public int? PhotoId { get; set; }
        public Photo Photo { get; set; }
    }
}
