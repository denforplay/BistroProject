using System.Collections.Generic;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.Recipes.Base
{
    public interface IRecipe<out T> where T : DishBase
    {
        List<IIngredient> Composition { get; init; }
        Queue<IIngredientsHandler> CookingSequence { get; init; }
        T Use(List<IIngredient> ingredients);
    }
}
