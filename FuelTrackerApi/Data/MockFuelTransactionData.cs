using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelTrackerApi.Data
{
    public class MockFuelTransactionData : IFuelTransactionData
    {
        //private readonly FuelTransactionContext _fuelTransactionContext;

        //public MockFuelTransactionData(FuelTransactionContext fuelTransactionContext)
        //{
        //    _fuelTransactionContext = fuelTransactionContext;
        //}
        private List<Vehicle> _vehicles = new List<Vehicle>();

        private List<FuelTransaction> _fuelTransactions = new List<FuelTransaction>();

        public MockFuelTransactionData()
        {
            DateTime.TryParse("2021-05-10", out DateTime date);
            Vehicle newVehicle = new Vehicle
            {
                Id = 1,
                Nickname = "Corolla",
                Make = "Toyota",
                Model = "Corolla",
                Year = 2017,
                Transactions = new List<FuelTransaction>()
            };

            newVehicle.AddTransaction(new FuelTransaction
            {
                Id = 1,
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
                Id = 2,
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
                Id = 3,
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

        public void CreateFuelTransaction(FuelTransaction FuelTransaction)
        {
            if (FuelTransaction == null)
                throw new ArgumentNullException(nameof(FuelTransaction));

            //_fuelTransactionContext.FuelTransactions.Add(FuelTransaction);
        }

        public void DeleteFuelTransaction(FuelTransaction FuelTransaction)
        {
            if (FuelTransaction == null)
                throw new ArgumentNullException(nameof(FuelTransaction));

            //_fuelTransactionContext.FuelTransactions.Remove(FuelTransaction);
        }

        public IEnumerable<FuelTransaction> GetAllFuelTransactions()
        {
            return _fuelTransactions;
            //return _fuelTransactionContext.FuelTransactions.ToList();
        }

        public FuelTransaction GetFuelTransactionById(int id)
        {
            return _fuelTransactions.FirstOrDefault(v => v.Id == id);
        }

        public void UpdateFuelTransaction(int id, FuelTransaction FuelTransaction)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return true;
            //return _fuelTransactionContext.SaveChanges() >= 0;
        }
    }
}