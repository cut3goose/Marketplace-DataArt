using System.Collections.Generic;

namespace OnlineShop.Product.Domain.Models
{
    public class CategoryListModel
    {
        public IEnumerable<CategoryModel> Categories { get; set; }
    }
}
