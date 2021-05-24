using FuelTrackerApi.Data;
using FuelTrackerApi.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelTrackerApi.Services
{
    public class FuelTransactionService
    {
        private readonly AppDbContext _context;

        public FuelTransactionService(AppDbContext fuelTransactionContext)
        {
            _context = fuelTransactionContext;
        }

        public void CreateFuelTransaction(FuelTransaction fuelTransaction)
        {
            if (fuelTransaction is null)
                throw new ArgumentNullException(nameof(fuelTransaction));

            _context.FuelTransactions.Add(fuelTransaction);
        }

        public void DeleteFuelTransaction(FuelTransaction fuelTransaction)
        {
            if (fuelTransaction == null)
                throw new ArgumentNullException(nameof(fuelTransaction));

            _context.FuelTransactions.Remove(fuelTransaction);
        }

        public IEnumerable<FuelTransaction> GetAllFuelTransactions()
        {
            return _context
                .FuelTransactions
                .Include(x => x.Vehicle)
                .ToList();
        }

        public FuelTransaction GetFuelTransactionById(int id)
        {
            return _context
                .FuelTransactions
                .Include(x => x.Vehicle)
                .Where(x => x.Id == id)
                .FirstOrDefault();
        }

        public void UpdateFuelTransaction(int id, FuelTransaction fuelTransaction)
        {
            //Nothing
        }
    }
}
