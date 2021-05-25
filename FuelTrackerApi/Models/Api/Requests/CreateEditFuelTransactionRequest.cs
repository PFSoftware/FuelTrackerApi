using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FuelTrackerApi.Models.Api.Requests
{
    public class CreateEditFuelTransactionRequest
    {
        public int? Id { get; set; }
        public int VehicleId { get; set; }

        public string Store { get; set; }
        public DateTime Date { get; set; }
        public int Octane { get; set; }
        public int Range { get; set; }
        public decimal Distance { get; set; }
        public decimal Gallons { get; set; }
        public decimal Odometer { get; set; }
        public decimal Price { get; set; }
    }
}
