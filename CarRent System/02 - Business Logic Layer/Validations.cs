namespace CarRent
{
  public class Validations
  {
    public static bool ValidateUserTelephone(UserModel userModel)
    {
      return userModel.telephone.Length > 9 && userModel.telephone.Length < 15;
    }

    public static bool ValidateUserPassword(UserModel userModel)
    {
      return userModel.password.Length > 5 && userModel.password.Length < 13;
    }
  }
}
