using System;

namespace FuelTrackerApi.Models.Domain
{
    /// <summary>Represents a fuel-up Transaction for a Vehicle.</summary>
    public class FuelTransaction
    {
        /// <summary>Transaction ID</summary>
        public int TranscationID { get; set; }

        /// <summary>Vehicle ID</summary>
        public int VehicleID { get; set; }

        /// <summary>Vehicle associated with the fuel transaction.</summary>
        public Vehicle Vehicle { get; set; }

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

        #region Override Operators

        private static bool Equals(FuelTransaction left, FuelTransaction right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return DateTime.Equals(left.Date, right.Date) && string.Equals(left.Store, right.Store, StringComparison.OrdinalIgnoreCase) && left.TranscationID == right.TranscationID && left.VehicleID == right.VehicleID && left.Odometer == right.Odometer && left.Range == right.Range && left.Distance == right.Distance && left.Gallons == right.Gallons && left.Odometer == right.Odometer && left.Price == right.Price;
        }

        public override bool Equals(object obj) => Equals(this, obj as FuelTransaction);

        public bool Equals(FuelTransaction other) => Equals(this, other);

        public static bool operator ==(FuelTransaction left, FuelTransaction right) => Equals(left, right);

        public static bool operator !=(FuelTransaction left, FuelTransaction right) => !Equals(left, right);

        public override int GetHashCode() => base.GetHashCode() ^ 17;

        #endregion Override Operators
    }
}