using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Recipes;
using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models
{
    public sealed class Order
    {
        private int _id;
        private List<Type> _dishesTypes;
        private DateTime _orderTime;

        public DateTime OrderTime => _orderTime;
        public List<Type> DishTypes => _dishesTypes;
        public Order(int id, List<Type> dishesTypes)
        {
            _id = id;
            _dishesTypes = dishesTypes;
            _orderTime = DateTime.Now;
        }
    }
}
