using System.Collections.Generic;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.Recipes.Base
{
    /// <summary>
    /// Provides base functionality 
    /// </summary>
    /// <typeparam name="T">Type of cooking dish</typeparam>
    public interface IRecipe<out T> where T : DishBase
    {
        /// <summary>
        /// Dish composition
        /// </summary>
        List<IIngredient> Composition { get; init; }

        /// <summary>
        /// Cooking sequence
        /// </summary>
        Queue<IIngredientsHandler> CookingSequence { get; init; }

        /// <summary>
        /// Method to use cook dish using recipe
        /// </summary>
        /// <param name="ingredients">List of ingredients from which cook dish</param>
        /// <returns></returns>
        T Use(List<IIngredient> ingredients);
    }
}
