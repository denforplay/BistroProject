using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.IngredientsHandlers
{
    /// <summary>
    /// Represents baking handler
    /// </summary>
    public sealed class Baking : IngredientHandlerBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Baking()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cost">Baking cost</param>
        /// <param name="duration">Baking duration</param>
        /// <param name="ingredients">List of ingredient to handle</param>
        public Baking(double cost, double duration, List<IIngredient> ingredients) : base(cost, duration, ingredients)
        {
        }
    }
}
