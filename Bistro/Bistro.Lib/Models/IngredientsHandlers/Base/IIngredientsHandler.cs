using System.Collections.Generic;
using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.IngredientsHandlers.Base
{
    /// <summary>
    /// Provides ingredient handler functionality
    /// </summary>
    public interface IIngredientsHandler
    {
        /// <summary>
        /// List of ingredients to handle
        /// </summary>
        List<IIngredient> Ingredients { get; set; }

        /// <summary>
        /// Handler cost
        /// </summary>
        double Cost { get; init; }

        /// <summary>
        /// Handler duration
        /// </summary>
        double Duration { get; init; }

        /// <summary>
        /// Handle operation
        /// </summary>
        void Handle();
    }
}
