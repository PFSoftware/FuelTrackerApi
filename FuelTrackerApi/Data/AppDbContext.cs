using FuelTrackerApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FuelTrackerApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<FuelTransaction> FuelTransactions { get; set; }
    }
}