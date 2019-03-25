using System.Security.Principal;
using System.Threading;
using System.Web.Http.Controllers;

namespace CarRent.Helper
{
    /// <summary>
    /// This class will impliment logic of authenticate service:
    /// </summary>
    public class AuthenticationService
    {
        public static void Authenticate(HttpActionContext actionContext)
        {
            string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
            TokenModel tokenModel = TokenService.ValidateToken(authenticationToken);
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(tokenModel.id.ToString()), new string[] { tokenModel.role });
        }

    }
}
