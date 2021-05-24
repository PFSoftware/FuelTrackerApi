using FuelTrackerApi.Models.Domain;
using System.Collections.Generic;

namespace FuelTrackerApi.Data
{
    public interface IFuelTransactionData
    {
        IEnumerable<FuelTransaction> GetAllFuelTransactions();

        FuelTransaction GetFuelTransactionById(int id);

        void CreateFuelTransaction(FuelTransaction FuelTransaction);

        void DeleteFuelTransaction(FuelTransaction FuelTransaction);

        void UpdateFuelTransaction(int id, FuelTransaction FuelTransaction);

        bool SaveChanges();
    }
}