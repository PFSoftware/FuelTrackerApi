using FuelTrackerApi.Data;
using FuelTrackerApi.Models.Api.Requests;
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

        public void UpdateFuelTransaction(CreateEditFuelTransactionRequest request, FuelTransaction fuelTransaction)
        {
            if (request.VehicleId != 0)
                fuelTransaction.VehicleId = request.VehicleId;
            if (request.Date != DateTime.MinValue)
                fuelTransaction.Date = request.Date;
            if (!string.IsNullOrWhiteSpace(request.Store))
                fuelTransaction.Store = request.Store;
            if (request.Octane != 0m)
                fuelTransaction.Octane = request.Octane;
            if (request.Distance != 0m)
                fuelTransaction.Distance = request.Distance;
            if (request.Gallons != 0m)
                fuelTransaction.Gallons = request.Gallons;
            if (request.Price != 0m)
                fuelTransaction.Price = request.Price;
            if (request.Odometer != 0m)
                fuelTransaction.Odometer = request.Odometer;
            if (request.Range != 0)
                fuelTransaction.Range = request.Range;

            _context.SaveChanges();
        }
    }
}