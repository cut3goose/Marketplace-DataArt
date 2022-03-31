using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Cart.Persistence.Entities;

namespace OnlineShop.Cart.Persistence.Configurations
{
    public class CartProductConfiguration : IEntityTypeConfiguration<CartProduct>
    {
        public void Configure(EntityTypeBuilder<CartProduct> builder)
        {
            builder.ToTable("cart_product");

            builder.HasKey(cp => new { cp.CartId, cp.ProductId });

            builder.Property(cp => cp.CartId)
                .HasColumnName("cart_id");

            builder.Property(cp => cp.ProductId)
                .HasColumnName("product_id");

            builder.Property(cp => cp.Quantity)
                .HasColumnName("quantity");

            builder.HasOne(cp => cp.Cart)
                .WithMany(c => c.CartProducts)
                .HasForeignKey(cp => cp.CartId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
