using System;
using OnlineShop.Contracts.Product.Enums;

namespace OnlineShop.Contracts.Product.Models
{
    public abstract class ReviewInteractionModel
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public Grade Grade { get; set; }
        public string Pros { get; set; }
        public string Cons { get; set; }
        public string Comment { get; set; }
    }
}
