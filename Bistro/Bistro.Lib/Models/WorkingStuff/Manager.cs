using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models.WorkingStuff
{
    public sealed class Manager
    {
        private List<Order> _orders;
        public IReadOnlyList<Order> Orders => _orders;

        public Manager()
        {
            _orders = new List<Order>();
        }

        public void TakeOrder(Order order)
        {
            if (order is null)
            {
                throw new ArgumentNullException();
            }

            _orders.Add(order);
        }
    }
}
