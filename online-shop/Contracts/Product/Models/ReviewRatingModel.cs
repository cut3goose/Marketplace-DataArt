using OnlineShop.Contracts.Product.Enums;

namespace OnlineShop.Contracts.Product.Models
{
    public class ReviewRatingModel
    {
        public int ReviewId { get; set; }
        public string UserId { get; set; }
        public Opinion Opinion { get; set; }
    }
}
