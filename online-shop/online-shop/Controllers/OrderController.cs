using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Contracts.Order.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Models;
using OnlineShop.Order.Domain;

namespace OnlineShop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderService _orderService;
        private readonly IMapper _mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            _orderService = orderService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult CreateOrder()
        {
            return View();
        }
        
        [HttpPost]
        public IActionResult CreateOrder(OrderCreateModel orderCreateModel)
        {
            _orderService.CreateOrder(orderCreateModel);
            return GetOrders().Result;
        }
        
        [HttpGet]
        public async Task<IActionResult> GetOrders(int pageNumber = 1, int pageSize = 4)
        {
            var paginationParams = new PaginationParameters {PageNumber = pageNumber, PageSize = pageSize};
            var ordersPaginatedList = await _orderService.GetAllOrdersByUser(paginationParams);

            var ordersViewModels = new List<OrderViewModel>();
            foreach (var selectedOrder in ordersPaginatedList.PageData)
            {
                ordersViewModels.Add(_mapper.Map<OrderViewModel>(selectedOrder));
            }
            
            return View(ordersViewModels.ToArray());
        }
    }
}