using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class ProductCategoryConfiguration : IEntityTypeConfiguration<ProductCategory>
    {
        public void Configure(EntityTypeBuilder<ProductCategory> builder)
        {
            builder.ToTable("product_category");

            builder.HasKey(pc => new { pc.ProductId, pc.CategoryId });

            builder.Property(pc => pc.ProductId)
                .HasColumnName("product_id");

            builder.Property(pc => pc.CategoryId)
                .HasColumnName("category_id");

            builder.HasOne(pc => pc.Product)
                .WithMany()
                .HasForeignKey(pc => pc.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pc => pc.Category)
                .WithMany()
                .HasForeignKey(pc => pc.CategoryId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
