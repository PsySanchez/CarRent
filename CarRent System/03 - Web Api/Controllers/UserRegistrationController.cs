using CarRent.Helper;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;


namespace CarRent
{
  [EnableCors("*", "*", "*")]
  [RoutePrefix("api")]
  public class UserRegistrationController: ApiController
  {
    private UsersLogic logic = new UsersLogic();

    [HttpPost]
    [Route("register")]
    public HttpResponseMessage UserRegistration(UserRegistrationViewModel userRegistrationViewModel)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorsHelper.GetErrorModel(ModelState));
        }

        if (logic.CheckIfUserExists(Mapper.MapUserRegistrationViewModelToUserModel(userRegistrationViewModel)))
        {
          return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
        }
        // map user registration view model to view model

        UserModel userModel = logic.AddUser(Mapper.MapUserRegistrationViewModelToUserModel(userRegistrationViewModel));
        
        return Request.CreateResponse(HttpStatusCode.Created, userRegistrationViewModel);
      }
      catch (Exception ex)
      {
        return Request.CreateResponse(HttpStatusCode.InternalServerError,
            ErrorsHelper.GetErrorModel(ex));
      }
    }
  }
}
