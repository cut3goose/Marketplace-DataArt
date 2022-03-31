namespace OnlineShop.Models
{
    public class CartProductModel
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string Equipment { get; set; }
        public string ImageLink { get; set; }
    }
}