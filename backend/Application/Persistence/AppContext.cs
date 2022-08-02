using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Persistence
{
    public interface IAppContext
    {
        DbSet<BoxType> BoxTypes { get; set; }
        DbSet<Customer> Customers { get; set; }
        DbSet<StorageArea> StorageAreas { get; set; }
        DbSet<StorageAreaHistory> StorageAreaHistory { get; set; }
    }

    public class AppContext : IAppContext
    {
        public DbSet<BoxType> BoxTypes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<StorageArea> StorageAreas { get; set; }  
        public DbSet<StorageAreaHistory> StorageAreaHistory { get; set; }
    }
}
