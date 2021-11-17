using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Dishes
{
    /// <summary>
    /// Represents new dish
    /// </summary>
    public sealed class NewDish : DishBase
    {
        private string _dishName;

        /// <summary>
        /// New dish constructor
        /// </summary>
        /// <param name="dishCost">Dish cost</param>
        /// <param name="ingredients">Ingredients</param>
        /// <param name="dishName">Dish name</param>
        public NewDish(double dishCost, List<IIngredient> ingredients, string dishName) : base(dishCost, ingredients)
        {
            _dishName = dishName;
        }

        public override string ToString()
        {
            return $"{_dishName} with cost {Cost}";
        }
    }
}
