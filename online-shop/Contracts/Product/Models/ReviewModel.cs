using System.Collections.Generic;

namespace OnlineShop.Contracts.Product.Models
{
    public class ReviewModel : ReviewInteractionModel
    {
        public int Id { get; set; }
        public IEnumerable<ReviewRatingModel> ReviewRatings { get; set; }
    }
}
