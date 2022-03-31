using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OnlineShop.Product.Persistence.Entities;

namespace OnlineShop.Product.Persistence.Configurations
{
    public class PhotoConfiguration : IEntityTypeConfiguration<Photo>
    {
        public void Configure(EntityTypeBuilder<Photo> builder)
        {
            builder.ToTable("photo");

            builder.Property(p => p.Id)
                .HasColumnName("photo_id");

            builder.Property(p => p.Size)
                .HasColumnName("size");

            builder.Property(p => p.File)
                .HasColumnName("file");
        }
    }
}
