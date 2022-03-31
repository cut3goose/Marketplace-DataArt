using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Entities.Product>
    {
        public void Configure(EntityTypeBuilder<Entities.Product> builder)
        {
            builder.ToTable("product");

            builder.Property(p => p.Id)
                .HasColumnName("product_id");

            builder.Property(p => p.CategoryId)
                .HasColumnName("category_id");

            builder.Property(p => p.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(p => p.Price)
                .HasColumnName("price")
                .HasColumnType("decimal(10,2)");

            builder.Property(p => p.Discount)
                .HasColumnName("discount");

            builder.Property(p => p.Description)
                .HasColumnName("description")
                .HasMaxLength(255);

            builder.Property(p => p.Quantity)
                .HasColumnName("quantity");

            builder.Property(p => p.Sku)
                .HasColumnName("sku");

            builder.Property(p => p.PublishedAt)
                .HasColumnName("published_at");

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
