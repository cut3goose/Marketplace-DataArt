using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.Order.Persistence.Configurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Entities.Order>
    {
        public void Configure(EntityTypeBuilder<Entities.Order> builder)
        {
            builder.ToTable("order");

            builder.Property(o => o.Id)
                .HasColumnName("order_id");

            builder.Property(o => o.UserId)
                .HasColumnName("user_id")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(o => o.Date)
                .HasColumnName("date");

            builder.Property(o => o.ShipDate)
                .HasColumnName("ship_date");

            builder.Property(o => o.CancelDate)
                .HasColumnName("cancel_date");

            builder.Property(o => o.CancelReason)
                .HasColumnName("cancel_reason");

            builder.Property(o => o.Status)
                .HasColumnName("status");

            builder.Property(o => o.ShippingType)
                .HasColumnName("shipping_type");

            builder.Property(o => o.ShippingPrice)
                .HasColumnName("shipping_price")
                .HasColumnType("decimal(10,2)");

            builder.Property(o => o.Address)
                .HasColumnName("address")
                .IsRequired();

            builder.Property(o => o.PaymentType)
                .HasColumnName("payment_type");
        }
    }
}
