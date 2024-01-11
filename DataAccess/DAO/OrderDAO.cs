using BusinessObject.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    internal class OrderDAO
    {
        private static OrderDAO instance;
        private static StoreContext _storeContext;

        internal OrderDAO(StoreContext context)
        {
            _storeContext = context;
        }

        internal static OrderDAO getInstance(StoreContext storeContext)
        {
            instance ??= new OrderDAO(new StoreContext());
            return instance;
        }

        internal List<Order> GetOrders()
        {
            return _storeContext.Orders.ToList();
        }

        internal Order? GetOrderById(int id)
        {
            return _storeContext.Orders.FirstOrDefault(o => o.OrderId == id);
        }

        internal Order AddOrder(Order order)
        {
            var o = _storeContext.Orders.Add(order).Entity;
            _storeContext.SaveChanges();
            return o;
        }

        internal Order UpdateOrder(Order order)
        {
            var o = _storeContext.Orders.Update(order).Entity;
            _storeContext.SaveChanges();
            return o;
        }

        internal bool DeleteOrder(int id)
        {
            var o = _storeContext.Orders.FirstOrDefault(o => o.OrderId == id);
            if (o == null) { return false; }

            OrderDetailDAO.getInstance().DeleteDetailByOrderId(id);
            _storeContext.Orders.Remove(o);

            var indexChanged = _storeContext.SaveChanges();
            return (indexChanged > 0);
        }
    }
}
