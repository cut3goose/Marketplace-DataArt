using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Order.Persistence.Entities;

namespace OnlineShop.Order.Persistence.Configurations
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.ToTable("transaction");

            builder.Property(t => t.Id)
                .HasColumnName("transaction_id");

            builder.Property(t => t.OrderId)
                .HasColumnName("order_id");

            builder.Property(t => t.UserId)
                .HasColumnName("user_id")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(t => t.Status)
                .HasColumnName("status");

            builder.HasOne(t => t.Order)
                .WithMany(o => o.Transactions)
                .HasForeignKey(o => o.OrderId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
