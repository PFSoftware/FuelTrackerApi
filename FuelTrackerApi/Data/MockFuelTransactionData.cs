using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelTrackerApi.Data
{
    public class MockFuelTransactionData : IFuelTransactionData
    {
        private readonly FuelTransactionContext _fuelTransactionContext;

        public MockFuelTransactionData(FuelTransactionContext fuelTransactionContext)
        {
            _fuelTransactionContext = fuelTransactionContext;
        }

        public void AddFuelTransaction(FuelTransaction FuelTransaction)
        {
            if (FuelTransaction == null)
                throw new ArgumentNullException(nameof(FuelTransaction));

            _fuelTransactionContext.FuelTransactions.Add(FuelTransaction);
        }

        public void DeleteFuelTransaction(FuelTransaction FuelTransaction)
        {
            if (FuelTransaction == null)
                throw new ArgumentNullException(nameof(FuelTransaction));

            _fuelTransactionContext.FuelTransactions.Remove(FuelTransaction);
        }

        public IEnumerable<FuelTransaction> GetAllFuelTransactions()
        {
            return _fuelTransactionContext.FuelTransactions.ToList();
        }

        public FuelTransaction GetFuelTransactionById(int id)
        {
            return _fuelTransactionContext.FuelTransactions.FirstOrDefault(v => v.TransactionID == id);
        }

        public void ModifyFuelTransaction(int id, FuelTransaction FuelTransaction)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return _fuelTransactionContext.SaveChanges() >= 0;
        }
    }
}