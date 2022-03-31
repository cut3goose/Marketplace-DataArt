using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using OnlineShop.Contracts.Cart.CartClient;
using OnlineShop.Contracts.Order.Enums;
using OnlineShop.Contracts.Order.Models;
using OnlineShop.Contracts.Payment;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Infrastructure.UserIdAccess.Interfaces;
using OnlineShop.Order.Persistence.Repository.Interfaces;
using EntityOrder = OnlineShop.Order.Persistence.Entities.Order;

namespace OnlineShop.Order.Domain
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repository;
        private readonly ICartClient _cartClient;
        private readonly IPaymentClient _paymentClient;
        private readonly IMapper _mapper;
        private readonly IUserIdService _userIdService;
        private const int DeliveryDays = 2;

        public OrderService(IOrderRepository repository, ICartClient cartClient, IPaymentClient paymentClient, IMapper mapper, 
            IUserIdService userIdService)
        {
            _repository = repository;
            _cartClient = cartClient;
            _paymentClient = paymentClient;
            _mapper = mapper;
            _userIdService = userIdService;
        }
        
        public async Task CreateOrder(OrderCreateModel orderCreateModel)
        {
            var order = _mapper.Map<OrderCreateModel, EntityOrder>(orderCreateModel);
            order.UserId = _userIdService.GetUserId();
            order.Status = OrderStatus.Active;
            order.PaymentType = PaymentType.Cash;
            order.Date = DateTime.Now;
            order.ShipDate = DateTime.Now.AddDays(DeliveryDays);
            order.ShippingPrice = _paymentClient.GetDeliveryPrice();

            await _repository.CreateOrder(order);
            await _cartClient.DeleteUserCart();
        }

        public async Task<PaginatedList<OrderModel>> GetAllOrdersByUser(PaginationParameters paginationParameters)
        {
            var userId = _userIdService.GetUserId();
            var entityOrdersPaginatedList = await _repository.GetAllOrdersByUser(userId, paginationParameters);

            var mappedOrderModelsPaginatedList = _mapper.Map<PaginatedList<OrderModel>>(entityOrdersPaginatedList);
            return mappedOrderModelsPaginatedList;
        }
    }
}