using System.Collections.Generic;

namespace OnlineShop.Product.Domain.Models
{
    public class TagListModel
    {
        public IEnumerable<TagModel> Tags { get; set; }
    }
}
