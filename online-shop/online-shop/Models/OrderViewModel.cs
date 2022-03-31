using System;
using OnlineShop.Contracts.Order.Enums;

namespace OnlineShop.Models
{
    public class OrderViewModel
    {
        public int Id { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public DateTime ShipDate { get; set; }
        public ShippingType ShippingType { get; set; }
        public decimal ShippingPrice { get; set; }
        public string Address { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}