using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FuelTrackerApi.Data
{
    public class DevDbSeeder
    {
        private AppDbContext _context;

        public DevDbSeeder()
        {
        }

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

            Vehicle vehicle2 = new Vehicle
            {
                Nickname = "CR-V",
                Make = "Honda",
                Model = "CR-V",
                Year = 2017,
                Transactions = new List<FuelTransaction>()
            };

            vehicle2.AddTransaction(new FuelTransaction
            {
                Vehicle = newVehicle,
                Store = "Kroger",
                Date = date,
                Octane = 87,
                Range = 157,
                Distance = 300.7m,
                Gallons = 30.17m,
                Odometer = 300.7m,
                Price = 30.179m
            });
            vehicle2.AddTransaction(new FuelTransaction
            {
                Vehicle = newVehicle,
                Store = "Shell",
                Date = date,
                Octane = 87,
                Range = 92,
                Distance = 400.7m,
                Gallons = 40.17m,
                Odometer = 400.7m,
                Price = 40.179m
            });
            _context.Vehicles.Add(newVehicle);
            _context.Vehicles.Add(vehicle2);

            await _context.SaveChangesAsync();
        }
    }
}