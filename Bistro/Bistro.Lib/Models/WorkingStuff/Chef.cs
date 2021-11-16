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
            if (recipe is null)
            {
                throw new ArgumentNullException(nameof(recipe));
            }

            if (ingredients is null || ingredients.Count == 0)
            {
                throw new ArgumentNullException(nameof(ingredients));
            }
            
            return recipe.Use(ingredients);
        }


        public RecipeBase<NewDish> CreateNewRecipe(List<IIngredient> composition, Queue<IIngredientsHandler> cookingSequence, string dishName)
        {
            if (composition is null || composition.Count == 0)
            {
                throw new ArgumentNullException(nameof(composition));
            }

            if (cookingSequence is null || cookingSequence.Count == 0)
            {
                throw new ArgumentNullException(nameof(cookingSequence));
            }

            if (String.IsNullOrEmpty(dishName))
            {
                throw new ArgumentNullException(nameof(dishName));
            }
            
            RecipeBase<NewDish> recipe = new NewRecipe(composition, cookingSequence, dishName);
            return recipe;
        }
    }
}
