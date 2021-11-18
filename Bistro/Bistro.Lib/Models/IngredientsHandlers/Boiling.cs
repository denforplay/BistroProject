using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.IngredientsHandlers
{
    /// <summary>
    /// Represents boiling handler
    /// </summary>
    public sealed class Boiling : IngredientHandlerBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Boiling()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cost">Boiling handler cost</param>
        /// <param name="duration">Boiling handler duration</param>
        /// <param name="ingredients">List of ingredients to boil</param>
        public Boiling(double cost, double duration, List<IIngredient> ingredients) : base(cost, duration, ingredients)
        {
        }
    }
}
