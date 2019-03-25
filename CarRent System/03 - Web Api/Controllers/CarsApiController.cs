using CarRent.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace CarRent
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class CarsApiController : ApiController
    {
        private CarsLogic logic = new CarsLogic();

        //Get all cars:
        [HttpGet]
        [Route("cars")]
        public HttpResponseMessage GetAllCarsTrue()
        {
            try
            {

                List<CarModel> allCars = logic.GetAllCars();
                // map carModel to carViewModel
                List<CarViewModel> allCarsViewModel = new List<CarViewModel>();
                foreach (var car in allCars)
                {
                    allCarsViewModel.Add(Mapper.MapCarModelToCarViewModel(car));
                }
                return Request.CreateResponse(HttpStatusCode.OK, allCarsViewModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        //Get car by id:
        [HttpGet]
        [Route("cars/{id}")]
        public HttpResponseMessage GetOneCar(int id)
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
                CarModel oneCar = logic.GetOneCar(id);

                CarViewModel oneCarModel = Mapper.MapCarModelToCarViewModel(oneCar);
                // map carModel to carViewModel
                return Request.CreateResponse(HttpStatusCode.OK, oneCarModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        //Get all car manufacturers:
        [HttpGet]
        [Route("manufacturer")]
        public HttpResponseMessage GetAllManufacturer()
        {
            try
            {
                //try
                //{
                //    AuthenticationService.Authenticate(ActionContext);
                //}
                //catch (Exception)
                //{
                //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                //}
                //if (!Thread.CurrentPrincipal.IsInRole("admin"))
                //{
                //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                //}

                List<ManufacturerModel> manufacturerModel = logic.GetAllManufacturer();
                List<ManufacturerViewModel> manufacturerViewModel = new List<ManufacturerViewModel>();
                foreach (var manufacturer in manufacturerModel)
                {
                    manufacturerViewModel.Add(Mapper.MapManufacturerModelToManufacturerViewModel(manufacturer));
                }

                return Request.CreateResponse(HttpStatusCode.OK, manufacturerViewModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        //Get all car models:
        [HttpGet]
        [Route("model")]
        public HttpResponseMessage GetAllCarModel()
        {
            try
            {
                //try
                //{
                //    AuthenticationService.Authenticate(ActionContext);
                //}
                //catch (Exception)
                //{
                //    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                //}
                //if (!Thread.CurrentPrincipal.IsInRole("admin"))
                //{
                //    return Request.CreateResponse(HttpStatusCode.InternalServerError);
                //}

                List<ModelCarModel> carModel = logic.GetAllModelCar();
                List<ModelCarViewModel> carViewModel = new List<ModelCarViewModel>();
                foreach (var model in carModel)
                {
                    carViewModel.Add(Mapper.MapModelCarModelToModelCarViewModel(model));
                }

                return Request.CreateResponse(HttpStatusCode.OK, carModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }
    }
}
