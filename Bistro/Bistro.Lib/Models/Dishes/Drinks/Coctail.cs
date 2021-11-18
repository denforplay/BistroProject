using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Dishes.Drinks
{
    /// <summary>
    /// Coctail drink
    /// </summary>
    public sealed class Coctail : ProductBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Coctail()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="dishCost">Coctail cost</param>
        /// <param name="ingredients">List of ingredients</param>
        public Coctail(double dishCost, List<IIngredient> ingredients) : base(dishCost, ingredients)
        {
        }
    }
}
