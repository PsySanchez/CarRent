using System;

namespace CarRent
{
    public class UserOrderModel
    {
        public int? id { get; set; }

        public int userId { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public DateTime fromDate { get; set; }

        public DateTime toDate { get; set; }

        public decimal totalCost { get; set; }

        public string manufacturer { get; set; }

        public string model { get; set; }

        public string photo { get; set; }
    }
}
