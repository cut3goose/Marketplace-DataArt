using System.Collections.Generic;

namespace OnlineShop.Product.Domain.Models
{
    public class ProductPhotosSetModel
    {
        public int ProductId { get; set; }
        public IEnumerable<int> PhotoIds { get; set; }
    }
}
