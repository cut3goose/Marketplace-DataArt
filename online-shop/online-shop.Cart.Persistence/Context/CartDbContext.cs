using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OnlineShop.Cart.Persistence.Entities;
using OnlineShop.Infrastructure.AuditableEntity;

namespace OnlineShop.Cart.Persistence.Context
{
    public class CartDbContext : DbContext
    {
        public CartDbContext(DbContextOptions<CartDbContext> options)
            : base(options)
        {
        }

        public DbSet<Entities.Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CartDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in ChangeTracker.Entries<AuditableEntity>())
            {
                switch (entry.State)
                {
                    case EntityState.Added:
                        entry.Entity.CreatedAt = DateTime.Now;
                        break;
                    case EntityState.Modified:
                        entry.Entity.UpdatedAt = DateTime.Now;
                        break;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
