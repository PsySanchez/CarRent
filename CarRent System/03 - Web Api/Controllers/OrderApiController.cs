using CarRent.Helper;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;
using System.Web.Http.Cors;
/// <summary>
/// Order processing controlle, allows you to add new orders
/// </summary>
namespace CarRent
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    public class OrderApiController : ApiController
    {
        private OrdersLogic logic = new OrdersLogic();

        [HttpPost]
        [Route("order")]
        public HttpResponseMessage AddOrder(OrderViewModel orderViewModel)
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
                if (!ModelState.IsValid)
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest, ErrorsHelper.GetErrorModel(ModelState));
                }
                if (logic.CheckIfOrderExists(Mapper.MapOrderViewModelToOrderModel(orderViewModel)))
                {
                    return Request.CreateResponse(HttpStatusCode.InternalServerError, "Internal Server Error");
                }
                OrderModel orderModel = Mapper.MapOrderViewModelToOrderModel(orderViewModel);
                orderModel.userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);
                logic.AddOrder(orderModel);
                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        [HttpGet]
        [Route("userOrders")]
        public HttpResponseMessage GetUserOrders()
        {
            try
            {
                try
                {
                    //autentication check
                    AuthenticationService.Authenticate(ActionContext);
                }
                catch (Exception)
                {
                    return Request.CreateResponse(HttpStatusCode.Unauthorized);
                }
                UserOrderModel orderModel = new UserOrderModel();
                orderModel.userId = int.Parse(Thread.CurrentPrincipal.Identity.Name);

                List<UserOrderModel> userOrders = logic.GetUserHistoryOrders(orderModel.userId);
                List<UserViewOrderModel> userViewOrders = new List<UserViewOrderModel>();
                foreach (var order in userOrders)
                {
                    if (orderModel.userId == order.userId)
                    {
                        userViewOrders.Add(Mapper.MapUserOrderModelToUserViewOrderModel(order));
                    }

                }
                return Request.CreateResponse(HttpStatusCode.OK, userViewOrders);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }

        [HttpGet]
        [Route("allOrders")]
        public HttpResponseMessage GetAllOrders()
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

                List<UserOrderModel> allOrders = logic.GetAllOrders();
                List<UserViewOrderModel> ordersVM = new List<UserViewOrderModel>();
                foreach (var order in allOrders)
                {
                    ordersVM.Add(Mapper.MapUserOrderModelToUserViewOrderModel(order));
                }
                return Request.CreateResponse(HttpStatusCode.OK, ordersVM);
            }

            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError,
                    ErrorsHelper.GetErrorModel(ex));
            }
        }
    }
}

