using System.Collections.Generic;
using AutoMapper;
using OnlineShop.Contracts.Order.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;
using EntityOrder = OnlineShop.Order.Persistence.Entities.Order;

namespace OnlineShop.Order.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderCreateModel, EntityOrder>();
            CreateMap<EntityOrder, OrderModel>();
            CreateMap<IEnumerable<EntityOrder>, IEnumerable<OrderModel>>();

            CreateMap<PaginatedList<EntityOrder>, PaginatedList<OrderModel>>()
                .ConvertUsing((source, destination, resContext) =>
                {
                    var mappedPageData = new List<OrderModel>();
                    foreach (var selectedPageData in source.PageData)
                    {
                        mappedPageData.Add(resContext.Mapper.Map<OrderModel>(selectedPageData));
                    }
                    
                    return new PaginatedList<OrderModel>(mappedPageData, source.PageNumber, source.PagesCount);
                });
        }
    }
}