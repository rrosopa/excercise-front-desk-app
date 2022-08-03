using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Application.Persistence
{
    public interface IAppDbContext
    {
        DbSet<BoxType> BoxTypes { get; }
        DbSet<Customer> Customers { get; }
        DbSet<StorageArea> StorageAreas { get; }
        DbSet<StorageAreaType> StorageAreaTypes { get; }
        public DbSet<StorageFacility> StorageFacilities { get; }
        DbSet<StorageAreaHistory> StorageAreaHistory { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }

    public class AppDbContext : DbContext, IAppDbContext
    {
        public DbSet<BoxType> BoxTypes => Set<BoxType>();
        public DbSet<Customer> Customers => Set<Customer>();
        public DbSet<StorageArea> StorageAreas => Set<StorageArea>();
        public DbSet<StorageAreaType> StorageAreaTypes => Set<StorageAreaType>();
        public DbSet<StorageFacility> StorageFacilities => Set<StorageFacility>();
        public DbSet<StorageAreaHistory> StorageAreaHistory => Set<StorageAreaHistory>();

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
