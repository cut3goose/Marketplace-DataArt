using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Order.Persistence.Entities;

namespace OnlineShop.Order.Persistence.Configurations
{
    public class OrderProductConfiguration : IEntityTypeConfiguration<OrderProduct>
    {
        public void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            builder.ToTable("order_product");

            builder.HasKey(op => new { op.OrderId, op.ProductId });

            builder.Property(op => op.OrderId)
                .HasColumnName("order_id");

            builder.Property(op => op.ProductId)
                .HasColumnName("product_id");

            builder.Property(op => op.Price)
                .HasColumnName("price")
                .HasColumnType("decimal(10,2)");

            builder.Property(op => op.Discount)
                .HasColumnName("discount");

            builder.Property(op => op.Quantity)
                .HasColumnName("quantity");

            builder.HasOne(op => op.Order)
                .WithMany(o => o.OrderProducts)
                .HasForeignKey(op => op.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
