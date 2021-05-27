using FuelTrackerApi.Data;
using FuelTrackerApi.Models.Api.Requests;
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
                .Include(x => x.Transactions)
                .FirstOrDefault(v => v.Id == id);
        }

        public void UpdateVehicle(CreateEditVehicleRequest request, Vehicle vehicle)
        {
            if (!string.IsNullOrWhiteSpace(request.Nickname))
                vehicle.Nickname = request.Nickname;
            if (!string.IsNullOrWhiteSpace(request.Make))
                vehicle.Make = request.Make;
            if (!string.IsNullOrWhiteSpace(request.Model))
                vehicle.Model = request.Model;
            if (request.Year != 0)
                vehicle.Year = request.Year;
            if (request.Transactions != null && request.Transactions.Count != 0)
                vehicle.Transactions = new List<FuelTransaction>(request.Transactions);
            _context.SaveChanges();
        }
    }
}