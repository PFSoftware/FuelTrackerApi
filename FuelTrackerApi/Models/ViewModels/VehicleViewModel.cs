using System.Collections.Generic;
using System.Linq;

namespace FuelTrackerApi.Models.ViewModels
{
    /// <summary>Represents an owned Vehicle.
    public class VehicleViewModel
    {
        /// <summary>Vehicle ID</summary>
        public int VehicleID { get; set; }

        /// <summary>Vehicle nickname</summary>
        public string Nickname { get; set; }

        /// <summary>Brand of Vehicle</summary>
        public string Make { get; set; }

        /// <summary>Model of Vehicle</summary>
        public string Model { get; set; }

        /// <summary>Model year of Vehicle</summary>
        public int Year { get; set; }

        /// <summary>List of Transactions associated with the current Vehicle.</summary>
        public List<FuelTransactionViewModel> Transactions { get; set; } = new List<FuelTransactionViewModel>();

        /// <summary>Miles per gallon</summary>
        public decimal MPG => Transactions.Count > 0 ? Transactions.Sum(trans => trans.MPG) / Transactions.Count : 0;

        /// <summary>Miles per gallon, formatted with three decimal places.</summary>
        public string MPGToString => MPG.ToString("N3");

        /// <summary>Miles per gallon, formatted with three decimal places, with preceding text.</summary>
        public string MPGToStringWithText => $"MPG: {MPGToString}";

        /// <summary>Total amount of money spent on fuel for this Vehicle.</summary>
        public decimal TotalCost => Transactions.Count > 0 ? Transactions.Sum(trans => trans.TotalPrice) : 0;

        /// <summary>Total amount of money spent on fuel for this Vehicle, formatted.</summary>
        public string TotalCostToString => TotalCost.ToString("C2");

        /// <summary>Total amount of money spent on fuel for this Vehicle, formatted, with text.</summary>
        public string TotalCostToStringWithText => $"Total Cost of Fuel: {TotalCostToString}";

        /// <summary>Average distance per fuel-up for this Vehicle.</summary>
        public decimal AverageDistance => Transactions.Count > 0
            ? Transactions.Sum(trans => trans.Distance) / Transactions.Count
            : 0;

        /// <summary>Average distance per fuel-up for this Vehicle, formatted.</summary>
        public string AverageDistanceToString => AverageDistance.ToString("N2");

        /// <summary>Average distance per fuel-up for this Vehicle, formatted, with text.</summary>
        public string AverageDistanceToStringWithText => $"Average distance between fuel-ups: {AverageDistanceToString}";

        /// <summary>Average gallons per fuel-up for this Vehicle.</summary>
        public decimal AverageGallons => Transactions.Count > 0
            ? Transactions.Sum(trans => trans.Gallons) / Transactions.Count
            : 0;

        /// <summary>Average gallons per fuel-up for this Vehicle, formatted.</summary>
        public string AverageGallonsToString => AverageGallons.ToString("N2");

        /// <summary>Average gallons per fuel-up for this Vehicle, formatted, with text.</summary>
        public string AverageGallonsToStringWithText => $"Average gallons per fuel-up: {AverageGallonsToString}";

        /// <summary>Average price per gallon per fuel-up for this Vehicle.</summary>
        public decimal AveragePrice => Transactions.Count > 0
            ? Transactions.Sum(trans => trans.Price) / Transactions.Count
            : 0;

        /// <summary>Average price per gallon per fuel-up for this Vehicle, formatted.</summary>
        public string AveragePriceToString => AveragePrice.ToString("C2");

        /// <summary>Average price per gallon per fuel-up for this Vehicle, formatted, with text.</summary>
        public string AveragePriceToStringWithText => $"Average price per gallon per fuel-up: {AveragePriceToString}";

        /// <summary>Average total price per fuel-up for this Vehicle.</summary>
        public decimal AverageTotalPrice => Transactions.Count > 0
            ? TotalCost / Transactions.Count
            : 0;

        /// <summary>Average total price per fuel-up for this Vehicle, formatted.</summary>
        public string AverageTotalPriceToString => AverageTotalPrice.ToString("C2");

        /// <summary>Average total price per fuel-up for this Vehicle, formatted, with text.</summary>
        public string AverageTotalPriceToStringWithText => $"Average price per fuel-up: {AverageTotalPriceToString}";
    }
}