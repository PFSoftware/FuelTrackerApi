using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;

namespace FuelTrackerApi.Data
{
    public class MockFuelTransactionData : IFuelTransactionData
    {
        //private readonly FuelTransactionContext _fuelTransactionContext;

        //public MockFuelTransactionData(FuelTransactionContext fuelTransactionContext)
        //{
        //    _fuelTransactionContext = fuelTransactionContext;
        //}

        private Vehicle newVehicle = new Vehicle
        {
            VehicleID = 1,
            Nickname = "Corolla",
            Make = "Toyota",
            Model = "Corolla",
            Year = 2017,
            Transactions = new List<FuelTransaction>()
        };

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
            DateTime.TryParse("2021-05-10", out DateTime date);
            return new List<FuelTransaction> {
            new FuelTransaction{TransactionId = 1,
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
            }}
            ;
            //return _fuelTransactionContext.FuelTransactions.ToList();
        }

        public FuelTransaction GetFuelTransactionById(int id)
        {
            DateTime.TryParse("2021-05-10", out DateTime date);
            return new FuelTransaction
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
            };
            //return _fuelTransactionContext.FuelTransactions.FirstOrDefault(v => v.TransactionID == id);
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