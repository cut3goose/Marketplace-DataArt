using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class ReviewConfiguration : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.ToTable("review");

            builder.Property(r => r.Id)
                .HasColumnName("review_id");

            builder.Property(r => r.ProductId)
                .HasColumnName("product_id");

            builder.Property(r => r.UserId)
                .HasColumnName("user_id")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(r => r.Date)
                .HasColumnName("date");

            builder.Property(r => r.Grade)
                .HasColumnName("grade");

            builder.Property(r => r.Pros)
                .HasColumnName("pros")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(r => r.Cons)
                .HasColumnName("cons")
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(r => r.Comment)
                .HasColumnName("comment")
                .IsRequired()
                .HasMaxLength(255);

            builder.HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
