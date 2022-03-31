using System.Collections.Generic;

namespace OnlineShop.Contracts.Product.Models
{
    public class FavoriteListModel
    {
        public IEnumerable<FavoriteModel> Favorites { get; set; }
    }
}
