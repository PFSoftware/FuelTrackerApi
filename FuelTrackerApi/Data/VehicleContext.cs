using FuelTrackerApi.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace FuelTrackerApi.Data
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) : base(options)
        {
        }

        public DbSet<Vehicle> Vehicles { get; set; }
    }
}