using System.Collections.Generic;

namespace CarRent
{
  public class CredentialsLogic : BaseLogic
  {
    private UsersLogic usersLogic = new UsersLogic();

    public UserModel Authentication(CredentialsModel credentialsModel)
    {
      List<UserModel> allUsers = usersLogic.GetAllUsers();
      // Check in database...
      foreach (var user in allUsers)
      {
        if (credentialsModel.username == user.userName && credentialsModel.password == user.password)
        {
          return user;
        }
      }
      return null;
    }
  }
}
