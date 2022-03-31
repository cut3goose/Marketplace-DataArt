using System.Collections.Generic;
using AutoMapper;
using OnlineShop.Contracts.Cart.CartProductModels;
using OnlineShop.Infrastructure.Models.PaginatedList;
using DomainCart = OnlineShop.Cart.Domain.Models.Cart;
using EntityCart = OnlineShop.Cart.Persistence.Entities.Cart;
using DomainCartProduct = OnlineShop.Cart.Domain.Models.CartProduct;
using EntityCartProduct = OnlineShop.Cart.Persistence.Entities.CartProduct;

namespace OnlineShop.Cart.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<EntityCart, DomainCart>();
            CreateMap<EntityCartProduct, DomainCartProduct>();
            CreateMap<DomainCartProduct, CartProductUpdateModel>();
            CreateMap<PaginatedList<EntityCartProduct>, PaginatedList<DomainCartProduct>>()
                .ConvertUsing((source, destination, resContext) =>
                {
                    var mappedPageData = new List<DomainCartProduct>();
                    foreach (var selectedPageData in source.PageData)
                    {
                        mappedPageData.Add(resContext.Mapper.Map<DomainCartProduct>(selectedPageData));
                    }
                    
                    return new PaginatedList<DomainCartProduct>(mappedPageData, source.PageNumber, source.PagesCount);
                });

            CreateMap<CartProductAddModel, EntityCartProduct>();
            CreateMap<CartProductAddModel, DomainCartProduct>();
        }
    }
}