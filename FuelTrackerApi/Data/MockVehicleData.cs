using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelTrackerApi.Data
{
    public class MockVehicleData : IVehicleData
    {
        //private readonly VehicleContext _vehicleContext;

        //public MockVehicleData(VehicleContext vehicleContext)
        //{
        //    _vehicleContext = vehicleContext;
        //}

        private List<Vehicle> _vehicles = new List<Vehicle>();

        private List<FuelTransaction> _fuelTransactions = new List<FuelTransaction>();

        public MockVehicleData()
        {
            DateTime.TryParse("2021-05-10", out DateTime date);
            Vehicle newVehicle = new Vehicle
            {
                VehicleID = 1,
                Nickname = "Corolla",
                Make = "Toyota",
                Model = "Corolla",
                Year = 2017,
                Transactions = new List<FuelTransaction>()
            };

            newVehicle.AddTransaction(new FuelTransaction
            {
                TransactionId = 1,
                VehicleId = 1,
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
                TransactionId = 2,
                VehicleId = 1,
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
                TransactionId = 3,
                VehicleId = 1,
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

            _vehicles.Add(newVehicle);
            foreach (Vehicle veh in _vehicles)
            {
                foreach (FuelTransaction ft in veh.Transactions)
                    _fuelTransactions.Add(ft);
            }
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            //_vehicleContext.Vehicles.Add(vehicle);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            //_vehicleContext.Vehicles.Remove(vehicle);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _vehicles;
            //}
            //}            }
            //return _vehicleContext.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicles.FirstOrDefault(v => v.VehicleID == id);
        }

        public void UpdateVehicle(int id, Vehicle vehicle)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return true;
            //return _vehicleContext.SaveChanges() >= 0;
        }
    }
}