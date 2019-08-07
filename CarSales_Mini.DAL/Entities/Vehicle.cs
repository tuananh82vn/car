using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CarSales_Mini.DAL.Entities
{
    public abstract class Vehicle
    {
        public int Id { get; set; }

        public string UniqueId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the Make of the vehicle.")]
        public string Make { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the Model of the vehicle.")]
        public string Model { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Please provide the Color of the vehicle.")]
        public string Color { get; set; }

        /// Type of vehicle - Bike or Car.
        public string VehicleType { get; set; }

        public bool IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
    }
}
