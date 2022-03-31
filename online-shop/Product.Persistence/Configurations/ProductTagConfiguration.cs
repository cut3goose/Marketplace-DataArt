using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class ProductTagConfiguration : IEntityTypeConfiguration<ProductTag>
    {
        public void Configure(EntityTypeBuilder<ProductTag> builder)
        {
            builder.ToTable("product_tag");

            builder.HasKey(pt => new { pt.ProductId, pt.TagId });

            builder.Property(pt => pt.ProductId)
                .HasColumnName("product_id");

            builder.Property(pt => pt.TagId)
                .HasColumnName("tag_id");

            builder.HasOne(pt => pt.Product)
                .WithMany(p => p.ProductTags)
                .HasForeignKey(pt => pt.ProductId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(pt => pt.Tag)
                .WithMany(t => t.ProductTags)
                .HasForeignKey(pt => pt.TagId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
