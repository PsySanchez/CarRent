
namespace CarRent
{
  public class Checker
  {
    public static bool CheckerOfPassportLength(string passport)
    {
      if (passport.Length <= 9)
      {
        return true;
      }
      return false;
    }

    public static bool CheckerOfPasswordtLength(string passport)
    {
      if (passport.Length <= 6)
      {
        return true;
      }
      return false;
    }
  }
}
