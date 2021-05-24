using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelTrackerApi.Data
{
    public class DevDbSeeder
    {
        private AppDbContext _context;

        public DevDbSeeder() { }

        public async Task SeedDatabase(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

            await SeedVehicles();
        }

        private async Task SeedVehicles()
        {
            DateTime date = DateTime.Parse("2021-05-10");

            Vehicle newVehicle = new Vehicle
            {
                Nickname = "Corolla",
                Make = "Toyota",
                Model = "Corolla",
                Year = 2017,
                Transactions = new List<FuelTransaction>()
            };

            newVehicle.AddTransaction(new FuelTransaction
            {
                Vehicle = newVehicle,
                Store = "Murphy USA",
                Date = date,
                Octane = 87,
                Range = 119,
                Distance = 182.7m,
                Gallons = 7.17m,
                Odometer = 23415.7m,
                Price = 2.179m
            });

            newVehicle.AddTransaction(new FuelTransaction
            {
                Vehicle = newVehicle,
                Store = "Murphy USA",
                Date = date,
                Octane = 87,
                Range = 519,
                Distance = 500.7m,
                Gallons = 50.17m,
                Odometer = 500.7m,
                Price = 50.179m
            });

            newVehicle.AddTransaction(new FuelTransaction
            {
                Vehicle = newVehicle,
                Store = "Murphy USA",
                Date = date,
                Octane = 87,
                Range = 219,
                Distance = 200.7m,
                Gallons = 20.17m,
                Odometer = 200.7m,
                Price = 20.179m
            });

            _context.Vehicles.Add(newVehicle);
            await _context.SaveChangesAsync();
        }


    }
}
