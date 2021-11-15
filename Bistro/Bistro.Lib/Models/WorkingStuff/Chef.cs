using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Recipes;
using System;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;
using Bistro.Lib.Models.Recipes.Base;

namespace Bistro.Lib.Models.WorkingStuff
{
    public sealed class Chef
    {
        public T Cook<T>(RecipeBase<T> recipe, List<IIngredient> ingredients) where T : DishBase
        {
            return recipe.Use(ingredients);
        }


        public RecipeBase<NewDish> CreateNewRecipe(List<IIngredient> composition, Queue<IIngredientsHandler> cookingSequence, string dishName)
        {
            RecipeBase<NewDish> recipe = new NewRecipe(composition, cookingSequence, dishName);
            return recipe;
        }
    }
}
