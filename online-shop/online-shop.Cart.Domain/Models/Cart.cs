using System.Collections.Generic;

namespace OnlineShop.Cart.Domain.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
    }
}