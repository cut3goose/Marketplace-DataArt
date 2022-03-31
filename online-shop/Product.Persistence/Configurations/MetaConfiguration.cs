using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class MetaConfiguration : IEntityTypeConfiguration<Meta>
    {
        public void Configure(EntityTypeBuilder<Meta> builder)
        {
            builder.ToTable("meta");

            builder.Property(m => m.Id)
                .HasColumnName("meta_id");

            builder.Property(m => m.ProductId)
                .HasColumnName("product_id");

            builder.Property(m => m.Type)
                .HasColumnName("type")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Key)
                .HasColumnName("key")
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(m => m.Value)
                .HasColumnName("value")
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(m => m.Product)
                .WithMany()
                .HasForeignKey(m => m.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
