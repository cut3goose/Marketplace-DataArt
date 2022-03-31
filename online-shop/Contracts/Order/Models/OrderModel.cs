using System;
using OnlineShop.Contracts.Order.Enums;

namespace OnlineShop.Contracts.Order.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public CancelReason? CancelReason { get; set; }
        public OrderStatus Status { get; set; }
        public ShippingType ShippingType { get; set; }
        public decimal ShippingPrice { get; set; }
        public string Address { get; set; }
        public PaymentType PaymentType { get; set; }
    }
}