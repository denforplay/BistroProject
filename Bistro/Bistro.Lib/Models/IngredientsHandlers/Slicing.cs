using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.IngredientsHandlers
{
    /// <summary>
    /// Represent slicing ingredient handler
    /// </summary>
    public sealed class Slicing : IngredientHandlerBase
    {
        /// <summary>
        /// Default constructor
        /// </summary>
        public Slicing()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="cost">Handler cost</param>
        /// <param name="duration">Handler duration</param>
        /// <param name="ingredients">List of ingredient to handle</param>
        public Slicing(double cost, double duration, List<IIngredient> ingredients) : base(cost, duration, ingredients)
        {
        }
    }
}
