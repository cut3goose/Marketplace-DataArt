using AutoMapper;
using OnlineShop.Contracts.Order.Models;
using OnlineShop.Models;

namespace OnlineShop.Mappings
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<OrderModel[], OrderViewModel[]>();
            CreateMap<OrderModel, OrderViewModel>();
        }
    }
}