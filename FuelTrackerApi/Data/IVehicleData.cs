using FuelTrackerApi.Models.Domain;
using System.Collections.Generic;

namespace FuelTrackerApi.Data
{
    public interface IVehicleData
    {
        IEnumerable<Vehicle> GetAllVehicles();

        Vehicle GetVehicleById(int id);

        void CreateVehicle(Vehicle vehicle);

        void DeleteVehicle(Vehicle vehicle);

        void UpdateVehicle(int id, Vehicle vehicle);

        bool SaveChanges();
    }
}