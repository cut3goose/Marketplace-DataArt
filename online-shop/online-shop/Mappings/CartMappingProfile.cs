using System.Collections.Generic;
using AutoMapper;
using OnlineShop.Cart.Domain.Models;
using OnlineShop.Infrastructure.Models.PaginatedList;
using OnlineShop.Models;
using DomainCart = OnlineShop.Cart.Domain.Models.Cart;

namespace OnlineShop.Mappings
{
    public class CartMappingProfile : Profile
    {
        public CartMappingProfile()
        {
            CreateMap<CartProduct, CartProductModel>();
            CreateMap<PaginatedList<CartProduct>, PaginatedList<CartProductModel>>()
                .ConvertUsing((source, destination, resContext) =>
                {
                    var mappedPageData = new List<CartProductModel>();
                    foreach (var selectedPageData in source.PageData)
                    {
                        mappedPageData.Add(resContext.Mapper.Map<CartProductModel>(selectedPageData));
                    }
                    
                    return new PaginatedList<CartProductModel>(mappedPageData, source.PageNumber, source.PagesCount);
                });
            
            CreateMap<DomainCart, CartModel>()
                .ConvertUsing((source, destination, resContext) =>
                {
                    var mappedCartProducts = new List<CartProductModel>();
                    foreach (var selectedCartProduct in source.CartProducts)
                    {
                        mappedCartProducts.Add(resContext.Mapper.Map<CartProductModel>(selectedCartProduct));
                    }

                    var mappedCart = new CartModel
                    {
                        Id = source.Id,
                        CartProducts = mappedCartProducts
                    };

                    return mappedCart;
                });
        }   
    }
}