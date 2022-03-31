using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class FavoriteConfiguration : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("favorite");

            builder.HasKey(f => new { f.ProductId, f.UserId });

            builder.Property(f => f.ProductId)
                .HasColumnName("product_id");

            builder.Property(f => f.UserId)
                .HasColumnName("user_id")
                .IsRequired()
                .HasMaxLength(64);

            builder.HasOne(f => f.Product)
                .WithMany()
                .HasForeignKey(f => f.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
