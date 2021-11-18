using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Dishes
{
    /// <summary>
    /// Represents salad type dishes
    /// </summary>
    public sealed class Salad : ProductBase
    {
        /// <summary>
        /// Salad constructor
        /// </summary>
        /// <param name="cost">Dish cost</param>
        /// <param name="ingredients">Salad composition</param>
        public Salad(double cost, List<IIngredient> ingredients) : base(cost, ingredients)
        {
        }
    }
}
