using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngridientsHandlers;
using Bistro.Lib.Models.Recipes;
using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models.WorkingStuff
{
    public sealed class Chef
    {
        public T Cook<T>(RecipeBase<T> recipe, List<IIngredient> ingredients) where T : DishBase
        {
            return recipe.Use(ingredients);
        }


        public RecipeBase<NewDish> CreateNewRecipe(List<IIngredient> composition, Queue<IIngredientHandler> cookingSequence, string dishName)
        {
            RecipeBase<NewDish> recipe = new NewRecipe(composition, cookingSequence, dishName);
            return recipe;
        }
    }
}
