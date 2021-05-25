using FuelTrackerApi.Data;
using FuelTrackerApi.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

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

            bool vehicleExists = _context.Vehicles.Where(x => x.Id == fuelTransaction.VehicleId).Any();

            if (!vehicleExists)
            {
                throw new InvalidOperationException("Cannot add transaction, vehicle not found");
            }

            _context.FuelTransactions.Add(fuelTransaction);

            _context.SaveChanges();
        }

        public void DeleteFuelTransaction(FuelTransaction fuelTransaction)
        {
            if (fuelTransaction == null)
                throw new ArgumentNullException(nameof(fuelTransaction));

            _context.FuelTransactions.Remove(fuelTransaction);

            _context.SaveChanges();
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