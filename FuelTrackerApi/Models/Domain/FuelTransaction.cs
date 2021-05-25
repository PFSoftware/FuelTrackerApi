using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuelTrackerApi.Models.Domain
{
    /// <summary>Represents a fuel-up Transaction for a Vehicle.</summary>
    public class FuelTransaction
    {
        /// <summary>Transaction ID</summary>
        [Key]
        public int Id { get; set; }

        //TODO Figure out how to get this to work the way Doug says it should.

        /// <summary>Vehicle ID</summary>
        public int VehicleId { get; set; }
        /// <summary>Vehicle associated with the fuel transaction.</summary>
        public Vehicle Vehicle { get; set; }

        /// <summary>Store where fuel was purchased.</summary>
        [Required]
        public string Store { get; set; }

        /// <summary>Date fuel was purchased.</summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>Octane of fuel purchased.</summary>
        [Required]
        public int Octane { get; set; }

        /// <summary>Estimated range vehicle.</summary>
        public int Range { get; set; }

        /// <summary>Distance travelled.</summary>
        [Column(TypeName = "decimal(10,3)")]
        public decimal Distance { get; set; }

        /// <summary>Gallons purchased.</summary>
        [Column(TypeName = "decimal(6,3)")]
        public decimal Gallons { get; set; }

        /// <summary>Odometer at fuel-up.</summary>
        [Column(TypeName = "decimal(7,1)")]
        public decimal Odometer { get; set; }

        /// <summary>Price of fuel per gallon.</summary>
        [Required]
        [Column(TypeName = "decimal(5,3)")]
        public decimal Price { get; set; }

        #region Override Operators

        private static bool Equals(FuelTransaction left, FuelTransaction right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return DateTime.Equals(left.Date, right.Date) && string.Equals(left.Store, right.Store, StringComparison.OrdinalIgnoreCase) && left.Id == right.Id && left.VehicleId == right.VehicleId && left.Odometer == right.Odometer && left.Range == right.Range && left.Distance == right.Distance && left.Gallons == right.Gallons && left.Odometer == right.Odometer && left.Price == right.Price;
        }

        public override bool Equals(object obj) => Equals(this, obj as FuelTransaction);

        public bool Equals(FuelTransaction other) => Equals(this, other);

        public static bool operator ==(FuelTransaction left, FuelTransaction right) => Equals(left, right);

        public static bool operator !=(FuelTransaction left, FuelTransaction right) => !Equals(left, right);

        public override int GetHashCode() => base.GetHashCode() ^ 17;

        #endregion Override Operators
    }
}