using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace OnlineShop.User.Persistence.Context
{
    public class UserDbContext : IdentityDbContext<Entities.User>
    {
        public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserDbContext).Assembly);

            modelBuilder.Entity<Entities.User>(entity => { entity.ToTable(name: "user"); });
            modelBuilder.Entity<IdentityRole>(entity => { entity.ToTable(name: "role"); });
            modelBuilder.Entity<IdentityUserRole<string>>(entity => { entity.ToTable("user_role"); });
            modelBuilder.Entity<IdentityUserClaim<string>>(entity => { entity.ToTable("user_claim"); });
            modelBuilder.Entity<IdentityUserLogin<string>>(entity => { entity.ToTable("user_login"); });
            modelBuilder.Entity<IdentityUserToken<string>>(entity => { entity.ToTable("user_token"); });
            modelBuilder.Entity<IdentityRoleClaim<string>>(entity => { entity.ToTable("role_claim"); });
        }
    }
}
