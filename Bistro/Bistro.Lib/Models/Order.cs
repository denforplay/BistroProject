using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models
{
    /// <summary>
    /// Represents order
    /// </summary>
    public sealed class Order
    {
        private int _id;
        private List<Type> _dishesTypes;
        private DateTime _orderTime;

        /// <summary>
        /// Order time
        /// </summary>
        public DateTime OrderTime => _orderTime;

        /// <summary>
        /// Type of cooking dishes
        /// </summary>
        public List<Type> DishTypes => _dishesTypes;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">Order id</param>
        /// <param name="dishesTypes">Cooking dish types</param>
        public Order(int id, List<Type> dishesTypes)
        {
            _id = id;
            _dishesTypes = dishesTypes;
            _orderTime = DateTime.Now;
        }
    }
}
