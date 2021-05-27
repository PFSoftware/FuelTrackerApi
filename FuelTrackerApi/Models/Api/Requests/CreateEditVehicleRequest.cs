using FuelTrackerApi.Models.Domain;
using System.Collections.Generic;

namespace FuelTrackerApi.Models.Api.Requests
{
    public class CreateEditVehicleRequest
    {
        public int? Id { get; set; }
        public string Nickname { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }
        public List<FuelTransaction> Transactions { get; set; } = new List<FuelTransaction>();
    }
}