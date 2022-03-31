using System;
using System.Collections.Generic;
using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Product.Persistence.Entities
{
    public class Product : AuditableEntity, IBaseEntity
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float? Discount { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public DateTime PublishedAt { get; set; }
        public ICollection<ProductTag> ProductTags { get; set; }
        public ICollection<ProductPhoto> ProductPhotos { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}
