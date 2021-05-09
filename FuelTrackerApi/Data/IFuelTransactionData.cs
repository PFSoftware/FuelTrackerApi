using FuelTrackerApi.Models.Domain;
using System.Collections.Generic;

namespace FuelTrackerApi.Data
{
    public interface IFuelTransactionData
    {
        IEnumerable<FuelTransaction> GetAllFuelTransactions();

        FuelTransaction GetFuelTransactionById(int id);

        void AddFuelTransaction(FuelTransaction FuelTransaction);

        void DeleteFuelTransaction(FuelTransaction FuelTransaction);

        void ModifyFuelTransaction(int id, FuelTransaction FuelTransaction);
    }
}