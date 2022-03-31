using System.Collections.Generic;

namespace OnlineShop.Models
{
    public class CartModel
    {
        public int Id { get; set; }
        public IEnumerable<CartProductModel> CartProducts { get; set; }
    }
}