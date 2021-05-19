using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;

namespace FuelTrackerApi.Data
{
    public class MockVehicleData : IVehicleData
    {
        //private readonly VehicleContext _vehicleContext;

        //public MockVehicleData(VehicleContext vehicleContext)
        //{
        //    _vehicleContext = vehicleContext;
        //}

        public void AddVehicle(Vehicle vehicle)
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
            List<Vehicle> allVehicles = new List<Vehicle>();
            Vehicle newVehicle = new Vehicle
            {
                VehicleID = 1,
                Nickname = "Corolla",
                Make = "Toyota",
                Model = "Corolla",
                Year = 2017,
                Transactions = new List<FuelTransaction>()
            };
            DateTime.TryParse("2021-05-10", out DateTime date);
            newVehicle.AddTransaction(new FuelTransaction
            {
                TransactionID = 1,
                VehicleID = 1,
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
                TransactionID = 2,
                VehicleID = 1,
                Vehicle = newVehicle,
                Store = "Murphy USA",
                Date = date,
                Octane = 87,
                Range = 119,
                Distance = 182.7m,
                Gallons = 7.17m,
                Odometer = 23415.7m,
                Price = 2.179m
            }); newVehicle.AddTransaction(new FuelTransaction
            {
                TransactionID = 3,
                VehicleID = 1,
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
            allVehicles.Add(newVehicle);
            return allVehicles;
            //}
            //}            }
            //return _vehicleContext.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return new Vehicle
            {
                VehicleID = 1,
                Nickname = "Corolla",
                Make = "Toyota",
                Model = "Corolla",
                Year = 2017,
                Transactions = new List<FuelTransaction>()
            };
            //return _vehicleContext.Vehicles.FirstOrDefault(v => v.VehicleID == id);
        }

        public void ModifyVehicle(int id, Vehicle vehicle)
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