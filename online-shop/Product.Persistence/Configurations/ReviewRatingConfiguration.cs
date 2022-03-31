using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class ReviewRatingConfiguration : IEntityTypeConfiguration<ReviewRating>
    {
        public void Configure(EntityTypeBuilder<ReviewRating> builder)
        {
            builder.ToTable("review_rating");

            builder.HasKey(rr => new { rr.ReviewId, rr.UserId });

            builder.Property(rr => rr.ReviewId)
                .HasColumnName("review_id");

            builder.Property(rr => rr.UserId)
                .HasColumnName("user_id")
                .IsRequired()
                .HasMaxLength(64);

            builder.Property(rr => rr.Opinion)
                .HasColumnName("opinion");

            builder.HasOne(rr => rr.Review)
                .WithMany()
                .HasForeignKey(rr => rr.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
