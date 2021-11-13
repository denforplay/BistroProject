using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Recipes
{
    public interface IRecipe<out T> where T : DishBase
    {
        IReadOnlyList<IIngredient> Composition { get; }
        T Use(List<IIngredient> ingredients);
    }
}
