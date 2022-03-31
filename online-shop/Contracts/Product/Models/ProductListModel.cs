using System.Collections.Generic;

namespace OnlineShop.Contracts.Product.Models
{
    public class ProductListModel
    {
        public IEnumerable<ProductModel> Products { get; set; }
    }
}
