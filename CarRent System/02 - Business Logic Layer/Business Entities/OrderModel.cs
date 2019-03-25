using System;

namespace CarRent
{
    public class OrderModel
    {
        public int? id { get; set; }
        public int userId { get; set; }
        public int carId { get; set; }
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public decimal totalCost { get; set; }
    }
}
