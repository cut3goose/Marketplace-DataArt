namespace OnlineShop.Product.Domain.Models
{
    public abstract class MetaInteractionModel
    {
        public int ProductId { get; set; }
        public string Type { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
