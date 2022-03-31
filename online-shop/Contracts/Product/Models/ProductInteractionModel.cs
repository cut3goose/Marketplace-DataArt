using System;

namespace OnlineShop.Contracts.Product.Models
{
    public abstract class ProductInteractionModel
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float? Discount { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string Sku { get; set; }
        public DateTime PublishedAt { get; set; }
    }
}
