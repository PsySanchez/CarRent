using CarRent.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarRent.Controllers
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/manufacturer")]
    public class ManufacturerController: ApiController
    {
        private ManagmentLogic logic = new ManagmentLogic();



    }
}