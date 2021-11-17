using System;
using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Models.WorkingStuff
{
    public sealed class Manager
    {
        public List<Order> Orders { get; set; }

        public Manager()
        {
            Orders = new List<Order>();
        }

        public void TakeOrder(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException();
            }

            Orders.Add(order);
        }

        public List<Order> FindAllOrders(DateTime fromDate, DateTime toDate)
        {
            var orders = Orders.Where(order => DateTime.Compare(order.OrderTime, fromDate) > 0 && DateTime.Compare(order.OrderTime, toDate) < 0).ToList();
            return orders;
        }
    }
}
