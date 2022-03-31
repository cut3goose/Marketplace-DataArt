using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OnlineShop.User.Persistence.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<Entities.User>
    {
        public void Configure(EntityTypeBuilder<Entities.User> builder)
        {
            builder.Property(u => u.Id)
                .HasMaxLength(64);

            builder.Property(u => u.FirstName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.LastName)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(u => u.PhoneNumber)
                .HasMaxLength(20);

            builder.Property(u => u.Email)
                .HasMaxLength(50);

            builder.Property(u => u.NormalizedEmail)
                .HasMaxLength(50);

            builder.Property(u => u.AdditionalInfo)
                .HasMaxLength(255);
        }
    }
}
