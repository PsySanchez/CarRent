using System.Collections.Generic;
using System.Linq;

namespace CarRent
{
    public class OrdersLogic : BaseLogic
    {
        public List<UserOrderModel> GetAllOrders()
        {
            return DB.UserOrders.Select(o => new UserOrderModel
            { 
                userId = o.UserId,
                firstName = o.FirstName,
                lastName = o.LastName,
                fromDate = o.FromDate,
                manufacturer = o.ManufacturerName,
                model = o.Model,
                toDate = o.ToDate,
                totalCost = o.TotalCost
            }).ToList();
        }

        public OrderModel GetOneOrder(int id)
        {
            return DB.Orders
              .Where(o => o.Id == id)
              .Select(o => new OrderModel
              {
                  userId = o.UserId,
                  carId = o.CarId,
                  fromDate = o.FromDate,
                  toDate = o.ToDate,
                  totalCost = o.TotalCost
              }).SingleOrDefault();
        }

        public List<UserOrderModel> GetUserHistoryOrders(int userId)
        {
            return DB.UserOrders
                .Where(o => o.UserId == userId)
                .Select(o => new UserOrderModel
                {
                    userId = o.UserId,
                    fromDate = o.FromDate,
                    toDate = o.ToDate,
                    totalCost = o.TotalCost,
                    manufacturer = o.ManufacturerName,
                    model = o.Model,
                    photo = o.Photo
                }).ToList();
        }

        public OrderModel AddOrder(OrderModel orderModel)
        {
            Order order = new Order
            {
                UserId = orderModel.userId,
                CarId = orderModel.carId,
                FromDate = orderModel.fromDate,
                ToDate = orderModel.toDate,
                TotalCost = orderModel.totalCost
            };
            DB.Orders.Add(order);
            DB.SaveChanges();

            return GetOneOrder(order.Id);
        }

        public bool CheckIfOrderExists(OrderModel orderModel)
        {
            return DB.Orders.Any(order => order.UserId == orderModel.userId &&
            order.FromDate == orderModel.fromDate &&
            order.ToDate == orderModel.toDate);
        }
    }
}
