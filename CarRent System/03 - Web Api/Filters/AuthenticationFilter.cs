using System;
using System.Net;
using System.Net.Http;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CarRent.Filters
{
  public class AuthenticationFilter : AuthorizationFilterAttribute
  {
    public override void OnAuthorization(HttpActionContext actionContext)
    {
      try
      {
        string authenticationToken = actionContext.Request.Headers.Authorization.Parameter;
        string decodetAuthenticationToken = Encoding.UTF8.GetString(Convert.FromBase64String(authenticationToken));
        string[] credentialsArray = decodetAuthenticationToken.Split(':');
        string userName = credentialsArray[0];
        string role = credentialsArray[1];
        Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userName), null);
      }
      catch (Exception)
      {
        actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
      }
    }
  }
}
