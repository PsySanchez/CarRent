using System;

namespace CarRent
{
    class UserHistoryOrderModel
    {

        public int? id { get; set; }

        public string manufacturer { get; set; }

        public string photo { get; set; }

        public int userId { get; set; }

        public DateTime fromDate { get; set; }

        public DateTime toDate { get; set; }

        public decimal totalCost { get; set; }
    }
}


