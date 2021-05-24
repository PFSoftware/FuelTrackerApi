using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelTrackerApi.Data
{
    public class SqlFuelTransactionData : IFuelTransactionData
    {
        private readonly VehicleContext _vehicleContext;

        public SqlFuelTransactionData(VehicleContext FuelTransactionContext)
        {
            _vehicleContext = FuelTransactionContext;
        }

        public void CreateFuelTransaction(FuelTransaction FuelTransaction)
        {
            if (FuelTransaction == null)
                throw new ArgumentNullException(nameof(FuelTransaction));

            _vehicleContext.FuelTransactions.Add(FuelTransaction);
        }

        public void DeleteFuelTransaction(FuelTransaction FuelTransaction)
        {
            if (FuelTransaction == null)
                throw new ArgumentNullException(nameof(FuelTransaction));

            _vehicleContext.FuelTransactions.Remove(FuelTransaction);
        }

        public IEnumerable<FuelTransaction> GetAllFuelTransactions()
        {
            return _vehicleContext.FuelTransactions.ToList();
        }

        public FuelTransaction GetFuelTransactionById(int id)
        {
            return _vehicleContext.FuelTransactions.FirstOrDefault(v => v.Id == id);
        }

        public void UpdateFuelTransaction(int id, FuelTransaction FuelTransaction)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return _vehicleContext.SaveChanges() >= 0;
        }
    }
}