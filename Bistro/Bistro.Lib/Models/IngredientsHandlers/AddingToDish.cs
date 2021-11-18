using System.Collections.Generic;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.IngredientsHandlers
{
    /// <summary>
    /// Represents adding to dish operation
    /// </summary>
    public sealed class AddingToDish : IngredientHandlerBase
    {
        /// <summary>
        /// Defaule constructor
        /// </summary>
        public AddingToDish()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cost">Adding to dish cost</param>
        /// <param name="duration">Handler duration</param>
        /// <param name="ingredients">List of ingredients to add</param>
        public AddingToDish(double cost, double duration, List<IIngredient> ingredients) : base(cost, duration, ingredients)
        {
        }
    }
}
