using System;

namespace CarRent
{
  public class CarViewModel
  {
    public int? id { get; set; }
    public string photo { get; set; }
    public string model { get; set; }
    public decimal pricePerDay { get; set; }
    public string carNumber { get; set; }
    public string manufacturer { get; set; }
  }
}
