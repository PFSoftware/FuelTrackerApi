using FuelTrackerApi.Data;
using FuelTrackerApi.Models.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelTrackerApi.Services
{
    public class VehicleService
    {
        private readonly AppDbContext _context;

        public VehicleService(AppDbContext context)
        {
            _context = context;
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            _context.Vehicles.Add(vehicle);
            _context.SaveChanges();
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            _context.Vehicles.Remove(vehicle);
            _context.SaveChanges();
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _context
                .Vehicles
                .Include(x => x.Transactions)
                .ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _context
                .Vehicles
                .Include(x => x.Transactions.Where(t => t.VehicleId == x.Id))
                .FirstOrDefault(v => v.Id == id);
        }

        public void UpdateVehicle(int id, Vehicle vehicle)
        {
            //Nothing
        }
    }
}