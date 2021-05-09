using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelTrackerApi.Data
{
    public class SqlVehicleData : IVehicleData
    {
        private readonly VehicleContext _vehicleContext;

        public SqlVehicleData(VehicleContext vehicleContext)
        {
            _vehicleContext = vehicleContext;
        }

        public void AddVehicle(Vehicle vehicle)
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
            return _vehicleContext.Vehicles.FirstOrDefault(v => v.VehicleID == id);
        }

        public void ModifyVehicle(int id, Vehicle vehicle)
        {
            //Nothing
        }

        public bool SaveChanges()
        {
            return _vehicleContext.SaveChanges() >= 0;
        }
    }
}