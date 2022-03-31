using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Cart.Persistence.Configurations
{
    public class CartConfiguration : IEntityTypeConfiguration<Entities.Cart>
    {
        public void Configure(EntityTypeBuilder<Entities.Cart> builder)
        {
            builder.ToTable("cart");

            builder.Property(c => c.Id)
                .HasColumnName("cart_id");

            builder.Property(c => c.UserId)
                .HasColumnName("user_id")
                .IsRequired()
                .HasMaxLength(64);
        }
    }
}
