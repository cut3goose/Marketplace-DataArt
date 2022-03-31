using System.Reflection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OnlineShop.Product.Domain.Services;
using OnlineShop.Product.Domain.Services.Interfaces;
using OnlineShop.Product.Persistence.Context;
using OnlineShop.Product.Persistence.Repositories;
using OnlineShop.Product.Persistence.Repositories.Interfaces;

namespace OnlineShop.Product.Domain
{
    public static class ProductModule
    {
        public static IServiceCollection AddProductModule(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ProductDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("OnlineShopDb"));
                options.UseSnakeCaseNamingConvention();
            });

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IFavoriteRepository, FavoriteRepository>();
            services.AddScoped<IMetaRepository, MetaRepository>();
            services.AddScoped<IPhotoRepository, PhotoRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IReviewRepository, ReviewRepository>();
            services.AddScoped<IReviewRatingRepository, ReviewRatingRepository>();
            services.AddScoped<ITagRepository, TagRepository>();

            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IFavoriteService, FavoriteService>();
            services.AddScoped<IMetaService, MetaService>();
            services.AddScoped<IPhotoService, PhotoService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IReviewService, ReviewService>();
            services.AddScoped<ITagService, TagService>();

            return services;
        }
    }
}
