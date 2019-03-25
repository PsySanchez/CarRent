namespace CarRent
{
    public class ModelCarModel
    {
        public int? id { get; set; }
        public string model { get; set; }
        public int manufacturerId { get; set; }
        public decimal pricePerDay { get; set; }
        public string photo { get; set; }
    }
}
