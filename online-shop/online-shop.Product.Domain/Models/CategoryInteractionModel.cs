namespace OnlineShop.Product.Domain.Models
{
    public abstract class CategoryInteractionModel
    {
        public int? ParentCategoryId { get; set; }
        public string Name { get; set; }
        public int? PhotoId { get; set; }
    }
}
