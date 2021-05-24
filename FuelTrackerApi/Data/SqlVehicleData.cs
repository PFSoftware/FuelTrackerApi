using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelTrackerApi.Data
{
    public class SqlVehicleData : IVehicleData
    {
        private readonly AppDbContext _vehicleContext;

        public SqlVehicleData(AppDbContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }

        public void CreateVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            _vehicleContext.Vehicles.Add(vehicle);
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            if (vehicle == null)
                throw new ArgumentNullException(nameof(vehicle));

            _vehicleContext.Vehicles.Remove(vehicle);
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            return _vehicleContext.Vehicles.ToList();
        }

        public Vehicle GetVehicleById(int id)
        {
            return _vehicleContext.Vehicles.FirstOrDefault(v => v.Id == id);
        }

        public void UpdateVehicle(int id, Vehicle vehicle)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return _vehicleContext.SaveChanges() >= 0;
        }
    }
}