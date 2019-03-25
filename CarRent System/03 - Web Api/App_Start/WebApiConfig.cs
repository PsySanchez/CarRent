using System.Web.Http;
using System.Web.Http.Cors;

namespace CarRent
{
  public static class WebApiConfig
  {
    public static void Register(HttpConfiguration config)
    {
      config.EnableCors();

      config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
      // Web API configuration and services

      // Web API routes
      config.MapHttpAttributeRoutes();

      config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
      config.Routes.MapHttpRoute(
          name: "DefaultApi",
          routeTemplate: "api/{controller}/{id}",
          defaults: new { id = RouteParameter.Optional }
      );
    }
  }
}
