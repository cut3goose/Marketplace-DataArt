using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(EntityTypeBuilder<Tag> builder)
        {
            builder.ToTable("tag");

            builder.Property(t => t.Id)
                .HasColumnName("tag_id");

            builder.Property(t => t.Name)
                .HasColumnName("name")
                .IsRequired()
                .HasMaxLength(20);
        }
    }
}
