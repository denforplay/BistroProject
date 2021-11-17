using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.Ingredients
{
    /// <summary>
    /// Provides ingredient functionality
    /// </summary>
    public interface IIngredient
    {
        /// <summary>
        /// Store conditions
        /// </summary>
        List<IStorageCondition> StoreConditions { get; init; }

        /// <summary>
        /// Ingredient handlers
        /// </summary>
        List<IIngredientsHandler> IngredientHandlers { get; init; }
        
        /// <summary>
        /// Ingredient cost
        /// </summary>
        double Cost { get; set; }

        /// <summary>
        /// Ingredient weight
        /// </summary>
        double Weight { get; set; }
    }
}
