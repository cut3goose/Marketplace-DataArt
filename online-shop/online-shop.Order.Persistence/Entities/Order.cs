using System;
using System.Collections.Generic;
using OnlineShop.Infrastructure.AuditableEntity;
using OnlineShop.Contracts.Order.Enums;
using OnlineShop.Infrastructure.DataAccess.Interfaces;

namespace OnlineShop.Order.Persistence.Entities
{
    public class Order : AuditableEntity, IBaseEntity
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public DateTime Date { get; set; }
        public DateTime ShipDate { get; set; }
        public DateTime? CancelDate { get; set; }
        public CancelReason? CancelReason { get; set; }
        public OrderStatus Status { get; set; }
        public ShippingType ShippingType { get; set; }
        public decimal ShippingPrice { get; set; }
        public string Address { get; set; }
        public PaymentType PaymentType { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}
