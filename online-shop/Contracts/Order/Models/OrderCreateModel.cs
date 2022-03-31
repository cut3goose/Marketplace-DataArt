using OnlineShop.Contracts.Order.Enums;

namespace OnlineShop.Contracts.Order.Models
{
    public class OrderCreateModel
    {
        public string Address { get; set; }
        public PaymentType PaymentType { get; set; }
        public ShippingType ShippingType { get; set; }
    }
}