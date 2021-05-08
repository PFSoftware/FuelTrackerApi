using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public void DeleteVehicle(Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            throw new NotImplementedException();
        }

        public Vehicle GetVehicleById(int id)
        {
            throw new NotImplementedException();
        }

        public void ModifyVehicle(int id, Vehicle vehicle)
        {
            throw new NotImplementedException();
        }
    }
}