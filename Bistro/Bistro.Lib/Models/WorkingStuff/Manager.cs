using System;
using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Models.WorkingStuff
{
    /// <summary>
    /// Represents manager
    /// </summary>
    public sealed class Manager
    {
        /// <summary>
        /// List of taken orders
        /// </summary>
        public List<Order> Orders { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public Manager()
        {
            Orders = new List<Order>();
        }

        /// <summary>
        /// Take order method
        /// </summary>
        /// <param name="order">Taken order</param>
        /// <exception cref="ArgumentNullException">Throws if order is null</exception>
        public void TakeOrder(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException();
            }

            Orders.Add(order);
        }

        /// <summary>
        /// Method for findilng all orders in date range
        /// </summary>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>List of orders in range</returns>
        public List<Order> FindAllOrders(DateTime fromDate, DateTime toDate)
        {
            var orders = Orders.Where(order => DateTime.Compare(order.OrderTime, fromDate) > 0 && DateTime.Compare(order.OrderTime, toDate) < 0).ToList();
            return orders;
        }
    }
}
