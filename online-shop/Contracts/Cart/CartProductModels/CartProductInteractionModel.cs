namespace OnlineShop.Contracts.Cart.CartProductModels
{
    public abstract class CartProductInteractionModel
    {
        public int ProductId { get; set; }
        public int CartId { get; set; }
    }
}