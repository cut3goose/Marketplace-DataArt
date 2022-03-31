using System.Collections.Generic;

namespace OnlineShop.Product.Domain.Models
{
    public class CategoryModel : CategoryInteractionModel
    {
        public int Id { get; set; }

        public IEnumerable<CategoryModel> SubCategories { get; set; }
    }
}