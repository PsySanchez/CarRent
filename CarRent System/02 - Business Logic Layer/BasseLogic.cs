using System;

namespace CarRent
{
  public class BaseLogic : IDisposable
  {
    protected CarRentEntities DB = new CarRentEntities();

    public void Dispose()
    {
      DB.Dispose();
    }
  }
}
