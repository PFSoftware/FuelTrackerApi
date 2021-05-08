using System;
using System.Collections.Generic;
using System.Linq;

namespace FuelTrackerApi.Models.Domain
{
    /// <summary>Represents an owned Vehicle.
    public class Vehicle
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
        public List<FuelTransaction> Transactions { get; set; } = new List<FuelTransaction>();

        /// <summary>Adds a Transaction to the list of Transactions.</summary>
        /// <param name="transaction">Transaction to be added</param>
        internal void AddTransaction(FuelTransaction transaction) => Transactions.Add(transaction);

        /// <summary>Modifies a Transaction in the list of Transactions.</summary>
        /// <param name="oldTransaction">Original Transaction to be replaced</param>
        /// <param name="newTransaction">New Transaction to replace old</param>
        internal void ModifyTransaction(FuelTransaction oldTransaction, FuelTransaction newTransaction) => Transactions.Replace(oldTransaction, newTransaction);

        /// <summary>Removes a Transaction from the list of Transactions.</summary>
        /// <param name="transaction">Transaction to be removed</param>
        internal void RemoveTransaction(FuelTransaction transaction) => Transactions.Remove(transaction);

        private static bool Equals(Vehicle left, Vehicle right)
        {
            if (left is null && right is null) return true;
            if (left is null ^ right is null) return false;
            return left.VehicleID == right.VehicleID && string.Equals(left.Nickname, right.Nickname, StringComparison.OrdinalIgnoreCase) && string.Equals(left.Make, right.Make, StringComparison.OrdinalIgnoreCase) && string.Equals(left.Model, right.Model, StringComparison.OrdinalIgnoreCase) && left.Year == right.Year && left.Transactions.Count == right.Transactions.Count && !left.Transactions.Except(right.Transactions).Any();
        }

        public override bool Equals(object obj) => Equals(this, obj as Vehicle);

        public bool Equals(Vehicle other) => Equals(this, other);

        public static bool operator ==(Vehicle left, Vehicle right) => Equals(left, right);

        public static bool operator !=(Vehicle left, Vehicle right) => !Equals(left, right);

        public override int GetHashCode() => base.GetHashCode() ^ 17;

        public override string ToString() => $"{VehicleID} - {Nickname}";
    }
}