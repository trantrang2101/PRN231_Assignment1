using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    internal class OrderDetailDAO
    {
        private static OrderDetailDAO instance;
        private static StoreContext _storeContext;

        internal OrderDetailDAO(StoreContext context)
        {
            _storeContext = context;
        }

        internal static OrderDetailDAO getInstance()
        {
            instance ??= new OrderDetailDAO(new StoreContext());
            return instance;
        }

        internal List<OrderDetail> GetOrderDetails()
        {
            return _storeContext.OrderDetails.ToList();
        }

        internal List<OrderDetail> GetOrdersByOrderId(int id)
        {
            return _storeContext.OrderDetails.Where(od => od.OrderId == id).ToList();
        }

        internal List<OrderDetail> GetOrdersByProductId(int id)
        {
            return _storeContext.OrderDetails.Where(od => od.ProductId == id).ToList();
        }

        internal OrderDetail AddOrderDetail(OrderDetail orderDetail) { 
            var od = _storeContext.OrderDetails.Add(orderDetail).Entity;
            _storeContext.SaveChanges();
            return od;
        }

        internal bool AddOrderDetails(List<OrderDetail> orderDetails)
        {
            _storeContext.OrderDetails.AddRange(orderDetails);
            var indexChanged = _storeContext.SaveChanges();
            return (indexChanged > 0);
        }

        internal bool DeleteDetailByOrderId(int orderId)
        {
            var orderDetails = _storeContext.OrderDetails.Where(od => od.OrderId == orderId).ToList();
            _storeContext.OrderDetails.RemoveRange(orderDetails);
            var indexChanged = _storeContext.SaveChanges();
            return (indexChanged > 0);
        }

        internal bool DeleteDetailByProductId(int productId)
        {
            var orderDetails = _storeContext.OrderDetails.Where(od => od.ProductId == productId).ToList();
            _storeContext.OrderDetails.RemoveRange(orderDetails);
            var indexChanged = _storeContext.SaveChanges();
            return (indexChanged > 0);
        }
    }
}
