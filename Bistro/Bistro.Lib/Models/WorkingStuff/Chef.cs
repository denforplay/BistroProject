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
    /// <summary>
    /// Represents chef
    /// </summary>
    public sealed class Chef
    {
        /// <summary>
        /// Method for cooking new dish using recipe
        /// </summary>
        /// <typeparam name="T">Type of cooking dish</typeparam>
        /// <param name="recipe">Recipe of cooking dish</param>
        /// <param name="ingredients">Ingredients from which cook dish</param>
        /// <returns>Cooked dish</returns>
        /// <exception cref="ArgumentNullException">Throws if recipe or ingredients are null</exception>
        public T Cook<T>(IRecipe<T> recipe, List<IIngredient> ingredients) where T : ProductBase
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

        /// <summary>
        /// Create new recipe method
        /// </summary>
        /// <param name="composition">Composition of new dish</param>
        /// <param name="cookingSequence">Cooking sequence of cooked dish</param>
        /// <param name="dishName">New dish name</param>
        /// <returns>New recipe</returns>
        /// <exception cref="ArgumentNullException">Throw if composition, cooking sequence or name is null</exception>
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
