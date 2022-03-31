using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("category");

            builder.Property(c => c.Id)
                .HasColumnName("category_id");

            builder.Property(c => c.ParentCategoryId)
                .HasColumnName("parent_category_id");

            builder.Property(c => c.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(20);

            builder.Property(c => c.PhotoId)
                .HasColumnName("photo_id");

            builder.HasOne(c => c.ParentCategory)
                .WithMany()
                .HasForeignKey(c => c.ParentCategoryId)
                .OnDelete(DeleteBehavior.ClientCascade);

            builder.HasOne(c => c.Photo)
                .WithOne()
                .HasForeignKey<Category>(c => c.PhotoId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
