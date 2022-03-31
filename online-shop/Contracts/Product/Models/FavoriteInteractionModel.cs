namespace OnlineShop.Contracts.Product.Models
{
    public abstract class FavoriteInteractionModel
    {
        public int ProductId { get; set; }
        public string UserId { get; set; }
    }
}
