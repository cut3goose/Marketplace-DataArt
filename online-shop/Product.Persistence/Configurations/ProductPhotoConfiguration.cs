using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class ProductPhotoConfiguration : IEntityTypeConfiguration<ProductPhoto>
    {
        public void Configure(EntityTypeBuilder<ProductPhoto> builder)
        {
            builder.ToTable("product_photo");

            builder.HasKey(pp => pp.PhotoId);

            builder.Property(pp => pp.PhotoId)
                .HasColumnName("photo_id");

            builder.Property(pp => pp.ProductId)
                .HasColumnName("product_id");

            builder.HasOne(pp => pp.Photo)
                .WithOne()
                .HasForeignKey<ProductPhoto>(pp => pp.PhotoId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pp => pp.Product)
                .WithMany(p => p.ProductPhotos)
                .HasForeignKey(pp => pp.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
