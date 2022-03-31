using System.IO;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using OnlineShop.Contracts.Product.Models;
using OnlineShop.Product.Domain.Models;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Domain.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<CategoryCreateModel, Category>();
            CreateMap<CategoryUpdateModel, Category>();
            CreateMap<Category, CategoryModel>();

            CreateMap<FavoriteCreateModel, Favorite>();
            CreateMap<Favorite, FavoriteModel>();

            CreateMap<MetaCreateModel, Meta>();
            CreateMap<MetaUpdateModel, Meta>();
            CreateMap<Meta, MetaModel>();

            CreateMap<ProductCreateModel, Persistence.Entities.Product>();
            CreateMap<ProductUpdateModel, Persistence.Entities.Product>();
            CreateMap<Persistence.Entities.Product, ProductModel>();

            CreateMap<ReviewCreateModel, Review>();
            CreateMap<ReviewUpdateModel, Review>();
            CreateMap<Review, ReviewModel>();

            CreateMap<ReviewRating, ReviewRatingModel>()
                .ReverseMap();

            CreateMap<TagCreateModel, Tag>();
            CreateMap<TagUpdateModel, Tag>();
            CreateMap<Tag, TagModel>();

            CreateMap<PhotoCreateModel, Photo>()
                .ForMember(dest => dest.File,
                    opt => opt.MapFrom(s => ConvertIFormFileToByteArray(s.File)));

            CreateMap<PhotoUpdateModel, Photo>()
                .ForMember(dest => dest.File,
                    opt => opt.MapFrom(s => ConvertIFormFileToByteArray(s.File)));

            CreateMap<Photo, PhotoModel>();
        }

        private byte[] ConvertIFormFileToByteArray(IFormFile file)
        {
            using var stream = new MemoryStream();
            file.CopyTo(stream);
            return stream.ToArray();
        }
    }
}
