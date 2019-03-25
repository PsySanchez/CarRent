using CarRent.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarRent
{
  [RoutePrefix("api")]
  [EnableCors("*", "*", "*")]
  public class UsersApiController : ApiController
  {
    private CredentialsLogic credentialsLogic = new CredentialsLogic();
        private UsersLogic userLogic = new UsersLogic();

    [HttpPost]
    [Route("authenticate")]
    public HttpResponseMessage Authenticate(CredentialsViewModel credentialsVM)
    {
      try
      {
        if (!ModelState.IsValid)
        {
          return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorsHelper.GetErrorModel(ModelState));
        }

        // Check credetials in database and get the correct user: 
        UserModel userModel = credentialsLogic.Authentication(Mapper.MapCredentialsViewModelToCredentialsModel(credentialsVM));
        AuthenticationViewModel autUser = Mapper.MapUserModelToAuthenticationViewModel(userModel);
        autUser.token = TokenService.GenerateToken(new TokenModel { role = userModel.role, userName = userModel.userName, id = userModel.id });

        return Request.CreateResponse(HttpStatusCode.OK, autUser);
      }
      catch (Exception ex)
      {
        // InternalServerError מקרה שני של אפשרות לשגיאות - מצב של חריגה
        return Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorsHelper.GetErrorModel(ex));
      }
    }

        [HttpGet]
        [Route("users")]
        public HttpResponseMessage GetAllUsers()
        {
            try
            {
                try
                {
                    AuthenticationService.Authenticate(ActionContext);
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }

                if (!Thread.CurrentPrincipal.IsInRole("admin"))
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                }

                List<UserModel> allUsers = userLogic.GetAllUsers();
                List<UserViewModel> allUserViewModels = new List<UserViewModel>();
                foreach (var user in allUsers)
                {
                    allUserViewModels.Add(Mapper.MapUserModelToUserViewModel(user));
                }

                return Request.CreateResponse(HttpStatusCode.Created, allUserViewModels); // Created 201
            }
            catch (Exception ex)
            {
                // InternalServerError 
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ErrorsHelper.GetErrorModel(ex));
            }
        }
    }
}
