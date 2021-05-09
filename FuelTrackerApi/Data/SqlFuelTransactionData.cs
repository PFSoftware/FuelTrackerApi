using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelTrackerApi.Data
{
    public class SqlFuelTransactionData : IFuelTransactionData
    {
        private readonly FuelTransactionContext _FuelTransactionContext;

        public SqlFuelTransactionData(FuelTransactionContext FuelTransactionContext)
        {
            _FuelTransactionContext = FuelTransactionContext;
        }

        public void AddFuelTransaction(FuelTransaction FuelTransaction)
        {
            if (FuelTransaction == null)
                throw new ArgumentNullException(nameof(FuelTransaction));

            _FuelTransactionContext.FuelTransactions.Add(FuelTransaction);
        }

        public void DeleteFuelTransaction(FuelTransaction FuelTransaction)
        {
            if (FuelTransaction == null)
                throw new ArgumentNullException(nameof(FuelTransaction));

            _FuelTransactionContext.FuelTransactions.Remove(FuelTransaction);
        }

        public IEnumerable<FuelTransaction> GetAllFuelTransactions()
        {
            return _FuelTransactionContext.FuelTransactions.ToList();
        }

        public FuelTransaction GetFuelTransactionById(int id)
        {
            return _FuelTransactionContext.FuelTransactions.FirstOrDefault(v => v.TransactionID == id);
        }

        public void ModifyFuelTransaction(int id, FuelTransaction FuelTransaction)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return _FuelTransactionContext.SaveChanges() >= 0;
        }
    }
}