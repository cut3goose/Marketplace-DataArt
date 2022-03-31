using System;
using System.Collections.Generic;
using OnlineShop.Contracts.Product.Enums;
using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Product.Persistence.Entities
{
    public class Review : AuditableEntity, IBaseEntity
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public Grade Grade { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public string Comment { get; set; }
        public ICollection<ReviewRating> ReviewRatings { get; set; }
    }
}
