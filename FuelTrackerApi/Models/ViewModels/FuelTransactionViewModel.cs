using System;

namespace FuelTrackerApi.Models.ViewModels
{
    /// <summary>Represents a fuel-up Transaction for a Vehicle.</summary>
    public class FuelTransactionViewModel
    {
        /// <summary>Transaction ID</summary>
        public int TransactionId { get; set; }

        /// <summary>Vehicle ID</summary>
        public int VehicleId { get; set; }

        /// <summary>Vehicle associated with the fuel transaction.</summary>
        public VehicleViewModel Vehicle { get; set; }

        /// <summary>Store where fuel was purchased.</summary>
        public string Store { get; set; }

        /// <summary>Date fuel was purchased.</summary>
        public DateTime Date { get; set; }

        /// <summary>Octane of fuel purchased.</summary>
        public int Octane { get; set; }

        /// <summary>Estimated range vehicle.</summary>
        public int Range { get; set; }

        /// <summary>Distance travelled.</summary>
        public decimal Distance { get; set; }

        /// <summary>Gallons purchased.</summary>
        public decimal Gallons { get; set; }

        /// <summary>Odometer at fuel-up.</summary>
        public decimal Odometer { get; set; }

        /// <summary>Price of fuel per gallon.</summary>
        public decimal Price { get; set; }

        /// <summary>Date fuel was purchased, formatted.</summary>
        public string DateToString => Date.ToString("yyyy/MM/dd");

        /// <summary>Distance travelled, formatted.</summary>
        public string DistanceToString => Distance.ToString("N1");

        /// <summary>Gallons purchased, formatted.</summary>
        public string GallonsToString => Gallons.ToString("N2");

        /// <summary>Miles per gallon.</summary>
        public decimal MPG => Distance / Gallons;

        /// <summary>Miles per gallon, formatted with three decimal places.</summary>
        public string MPGToString => MPG.ToString("N3");

        /// <summary>Total price of the transaction.</summary>
        public string OdometerToString => Odometer.ToString("N1");

        /// <summary>Total price of fuel, formatted to currency.</summary>
        public string PriceToString => Price.ToString("C3");

        /// <summary>Total price of the transaction.</summary>
        public decimal TotalPrice => Price * Gallons;

        /// <summary>Total price of the transaction, formatted to currency.</summary>
        public string TotalPriceToString => TotalPrice.ToString("C2");

        public override string ToString() => $"{DateToString} - {Store}";
    }
}