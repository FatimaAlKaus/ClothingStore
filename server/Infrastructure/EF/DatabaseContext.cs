namespace Infrastructure.EF
{
    using System;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Domain.Models;
    using Microsoft.EntityFrameworkCore;

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
                 : base(options)
        {
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Cart> Carts { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Comment> Comments { get; set; }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            ProcessSave();
            return await base.SaveChangesAsync(cancellationToken);
        }

        public override int SaveChanges()
        {
            ProcessSave();
            return base.SaveChanges();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
           .HasOne(u => u.Cart)
           .WithOne(c => c.User)
           .HasForeignKey<Cart>(c => c.Id);
        }

        private void ProcessSave()
        {
            var dateTime = DateTimeOffset.Now;
            foreach (var item in ChangeTracker.Entries()
                .Where(x => (x.State == EntityState.Added || x.State == EntityState.Modified) && x.Entity is BaseEntity))
            {
                var entity = item.Entity as BaseEntity;
                if (item.State == EntityState.Added)
                {
                    entity.CreatedDate = dateTime;
                }

                entity.ModifiedDate = dateTime;

                item.Property(nameof(entity.ModifiedDate)).IsModified = true;
                item.Property(nameof(entity.CreatedDate)).IsModified = false;
            }
        }
    }
}
