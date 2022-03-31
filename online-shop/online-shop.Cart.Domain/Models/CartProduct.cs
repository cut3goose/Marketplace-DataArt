namespace OnlineShop.Cart.Domain.Models
{
    public class CartProduct
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public int CartId { get; set; }
    }
}