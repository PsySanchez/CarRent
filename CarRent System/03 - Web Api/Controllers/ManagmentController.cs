using CarRent.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarRent.Controllers
{

    [EnableCors("*", "*", "*")]
    [RoutePrefix("api/managment")]
    public class ManagmentController : ApiController
    {
        private ManagmentLogic logic = new ManagmentLogic();

        //Company Fleet managment controller:
        [HttpGet]
        [Route("companyFleet/{id}")]
        public HttpResponseMessage GetCompanyFleet(int id)
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

                CompanyFleetViewModel companyFleet = Mapper.MapCompanyFleetModelToCompanyFleetVIewModel(logic.GetOneCompanyFleet(id));

                return Request.CreateResponse(HttpStatusCode.OK, companyFleet);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        //Add new car to company fleet:
        [HttpPost]
        [Route("companyFleet")]
        public HttpResponseMessage AddCompanyFleet(CompanyFleetViewModel companyFleetViewModel)
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
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorsHelper.GetErrorModel(ModelState));
                }
                if (logic.CheckIfCompanyCarExists(Mapper.MapCompanyFleetViewModelToCompanyFleetModel(companyFleetViewModel)))
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
                }

                CompanyFleetModel companyFleetModel = Mapper.MapCompanyFleetViewModelToCompanyFleetModel(companyFleetViewModel);
                logic.AddCompanyFleet(companyFleetModel);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        //Get all cars from company fleet
        [HttpGet]
        [Route("companyFleet")]
        public HttpResponseMessage GetAllCompanyFleet()
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

                List<CompanyFleetModel> companyFleet = logic.GetAllCompanyFleet();
                List<CompanyFleetViewModel> companyFleetViewModels = new List<CompanyFleetViewModel>();
                foreach (var cf in companyFleet)
                {
                    companyFleetViewModels.Add(Mapper.MapCompanyFleetModelToCompanyFleetVIewModel(cf));
                }

                return Request.CreateResponse(HttpStatusCode.OK, companyFleetViewModels);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        //Update car number in company fleet by id:
        [HttpPatch]
        [Route("companyFleet/{id}")]
        public HttpResponseMessage UpdateCompanyFleet(int id, CompanyFleetViewModel companyFleetViewModel)
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

                companyFleetViewModel.id = id;

                if (logic.CheckIfCompanyCarExists(Mapper.MapCompanyFleetViewModelToCompanyFleetModel(companyFleetViewModel)))
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
                }

                CompanyFleetModel companyFleetModel = Mapper.MapCompanyFleetViewModelToCompanyFleetModel(companyFleetViewModel);
                companyFleetViewModel = Mapper.MapCompanyFleetModelToCompanyFleetVIewModel(logic.UpdateCarNumber(companyFleetModel));

                return Request.CreateResponse(HttpStatusCode.OK, companyFleetViewModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        //Deleate car from company fleet:
        [HttpDelete]
        [Route("companyFleet/{id}")]
        public HttpResponseMessage DeleateCompanyFleet(int id)
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

                logic.DeleteCompanyFleet(id);

                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        //Quite the code below not used in the project, but was already writen, 
        //Get car by id:

        // Manufacturer managment controller:
        //[HttpGet]
        //[Route("manufacturer/{id}")]
        //public HttpResponseMessage GetManufacturer(int id)
        //{
        //    try
        //    {
        //        //try
        //        //{
        //        //    AuthenticationService.Authenticate(ActionContext);
        //        //}
        //        //catch (Exception)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        //}
        //        //if (!Thread.CurrentPrincipal.IsInRole("admin"))
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //        //}

        //        ManufacturerModel manufacturer = logic.GetOneManufacturer(id);

        //        return Request.CreateResponse(HttpStatusCode.OK, manufacturer);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError,
        //            ErrorsHelper.GetErrorModel(ex));
        //    }
        //}

        //[HttpPost]
        //[Route("manufacturer")]
        //public HttpResponseMessage AddManufacturer(ManufacturerViewModel manufacturerViewModel)
        //{
        //    try
        //    {
        //        //try
        //        //{
        //        //    AuthenticationService.Authenticate(ActionContext);
        //        //}
        //        //catch (Exception)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        //}
        //        //if (!Thread.CurrentPrincipal.IsInRole("admin"))
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //        //}
        //        //if (!ModelState.IsValid)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorsHelper.GetErrorModel(ModelState));
        //        //}
        //        if (logic.CheckIfManufacturerExists(Mapper.MapManufacturerViewModelToManufacturerModel(manufacturerViewModel)))
        //        {
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
        //        }

        //        ManufacturerModel manufacturerModel = Mapper.MapManufacturerViewModelToManufacturerModel(manufacturerViewModel);
        //        logic.AddManufacturer(manufacturerModel);
        //        return Request.CreateResponse(HttpStatusCode.OK, "OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError,
        //            ErrorsHelper.GetErrorModel(ex));
        //    }
        //}

        //[HttpPatch]
        //[Route("manufacturer/{id}")]
        //public HttpResponseMessage UpdateManufacturer(int id, ManufacturerViewModel manufacturerViewModel)
        //{
        //    try
        //    {
        //        //try
        //        //{
        //        //    AuthenticationService.Authenticate(ActionContext);
        //        //}
        //        //catch (Exception)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        //}
        //        //if (!Thread.CurrentPrincipal.IsInRole("admin"))
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //        //}

        //        manufacturerViewModel.id = id;

        //        if (logic.CheckIfManufacturerExists(Mapper.MapManufacturerViewModelToManufacturerModel(manufacturerViewModel)))
        //        {
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
        //        }

        //        ManufacturerModel manufacturerModel = Mapper.MapManufacturerViewModelToManufacturerModel(manufacturerViewModel);

        //        manufacturerViewModel = Mapper.MapManufacturerModelToManufacturerViewModel(logic.UpdateManufacturerName(manufacturerModel));

        //        return Request.CreateResponse(HttpStatusCode.OK, manufacturerViewModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError,
        //            ErrorsHelper.GetErrorModel(ex));
        //    }
        //}

        //[HttpDelete]
        //[Route("manufacturer/{id}")]
        //public HttpResponseMessage DeleateManufacturer(int id)
        //{
        //    try
        //    {
        //        //try
        //        //{
        //        //    AuthenticationService.Authenticate(ActionContext);
        //        //}
        //        //catch (Exception)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        //}
        //        //if (!Thread.CurrentPrincipal.IsInRole("admin"))
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //        //}

        //        logic.DeleteManufacturer(id);

        //        return Request.CreateResponse(HttpStatusCode.OK, "OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError,
        //            ErrorsHelper.GetErrorModel(ex));
        //    }
        //}
        ////----------------------End of Manufacturer Controller----------------------------//

        //// Model managment controller:
        //[HttpGet]
        //[Route("model/{id}")]
        //public HttpResponseMessage GetCarModel(int id)
        //{
        //    try
        //    {
        //        //try
        //        //{
        //        //    AuthenticationService.Authenticate(ActionContext);
        //        //}
        //        //catch (Exception)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        //}
        //        //if (!Thread.CurrentPrincipal.IsInRole("admin"))
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //        //}

        //        ModelCarViewModel carModel = Mapper.MapModelCarModelToModelCarViewModel(logic.GetOneModelCar(id));

        //        return Request.CreateResponse(HttpStatusCode.OK, carModel);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError,
        //            ErrorsHelper.GetErrorModel(ex));
        //    }
        //}

        //[HttpPost]
        //[Route("model")]
        //public HttpResponseMessage AddModelCar(ModelCarViewModel modelCarViewModel)
        //{
        //    try
        //    {
        //        //try
        //        //{
        //        //    AuthenticationService.Authenticate(ActionContext);
        //        //}
        //        //catch (Exception)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        //}
        //        //if (!Thread.CurrentPrincipal.IsInRole("admin"))
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //        //}
        //        //if (!ModelState.IsValid)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorsHelper.GetErrorModel(ModelState));
        //        //}
        //        if (logic.CheckIfModelCarExists(Mapper.MapModelCarViewModelToModelCarModel(modelCarViewModel)))
        //        {
        //            return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
        //        }

        //        ModelCarModel modelCarModel = Mapper.MapModelCarViewModelToModelCarModel(modelCarViewModel);
        //        logic.AddModelCar(modelCarModel);
        //        return Request.CreateResponse(HttpStatusCode.OK, "OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError,
        //            ErrorsHelper.GetErrorModel(ex));
        //    }
        //}

        //[HttpPatch]
        //[Route("model/{id}")]
        //public HttpResponseMessage UpdateModel(int id, ModelCarViewModel modelViewCar)
        //{
        //    try
        //    {
        //        //try
        //        //{
        //        //    AuthenticationService.Authenticate(ActionContext);
        //        //}
        //        //catch (Exception)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        //}
        //        //if (!Thread.CurrentPrincipal.IsInRole("admin"))
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //        //}

        //        modelViewCar.id = id;
        //        ModelCarModel carModel = Mapper.MapModelCarViewModelToModelCarModel(modelViewCar);

        //        modelViewCar = Mapper.MapModelCarModelToModelCarViewModel(logic.UpdateModelCarPrice(carModel));

        //        return Request.CreateResponse(HttpStatusCode.OK, modelViewCar);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError,
        //            ErrorsHelper.GetErrorModel(ex));
        //    }
        //}

        //[HttpDelete]
        //[Route("model/{id}")]
        //public HttpResponseMessage DeleateModel(int id)
        //{
        //    try
        //    {
        //        //try
        //        //{
        //        //    AuthenticationService.Authenticate(ActionContext);
        //        //}
        //        //catch (Exception)
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
        //        //}
        //        //if (!Thread.CurrentPrincipal.IsInRole("admin"))
        //        //{
        //        //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
        //        //}

        //        logic.DeleteModelCar(id);

        //        return Request.CreateResponse(HttpStatusCode.OK, "OK");
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateResponse(HttpStatusCode.InternalServerError,
        //            ErrorsHelper.GetErrorModel(ex));
        //    }
        //}
        //----------------------End of Model Controller----------------------------//

    }
}