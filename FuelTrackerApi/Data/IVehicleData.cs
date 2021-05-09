using FuelTrackerApi.Models.Domain;
using System.Collections.Generic;

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