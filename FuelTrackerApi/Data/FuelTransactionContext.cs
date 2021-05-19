using FuelTrackerApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FuelTrackerApi.Data
{
    public class FuelTransactionContext : DbContext
    {
        public FuelTransactionContext(DbContextOptions<FuelTransactionContext> options) : base(options)
        {
        }

        public DbSet<FuelTransaction> FuelTransactions { get; set; }
    }
}
