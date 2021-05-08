using FuelTrackerApi.Models.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelTrackerApi.Data
{
    public interface IVehicleData
    {
        IEnumerable<Vehicle> GetAllVehicles();

        Vehicle GetVehicleById(int id);

        void AddVehicle(Vehicle vehicle);

        void DeleteVehicle(Vehicle vehicle);

        void ModifyVehicle(int id, Vehicle vehicle);
    }
}