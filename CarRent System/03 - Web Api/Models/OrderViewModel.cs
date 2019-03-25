using System;
using System.ComponentModel.DataAnnotations;

namespace CarRent
{
    public class OrderViewModel
    {
        public int? id { get; set; }

        [Required]
        public int carId { get; set; }

        [Required]
        public DateTime fromDate { get; set; }

        [Required]
        public DateTime toDate { get; set; }

        [Required]
        public decimal totalCost { get; set; }
    }
}
