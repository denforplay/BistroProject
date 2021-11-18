using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using System;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers.Base;
using Bistro.Lib.Models.Recipes.Base;

namespace Bistro.Lib.Models.Recipes
{
    public sealed class NewRecipe : RecipeBase<NewDish>
    {
        /// <summary>
        /// Name of cooking dish
        /// </summary>
        public string DishName { get; set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public NewRecipe()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="composition">Composition of new dish</param>
        /// <param name="cookingSequence">New dish cooking sequence</param>
        /// <param name="dishName">Name of dish</param>
        /// <exception cref="ArgumentNullException">Throws if composition or cooking sequence is null</exception>
        public NewRecipe(List<IIngredient> composition, Queue<IIngredientsHandler> cookingSequence, string dishName)
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

            Composition = composition;
            CookingSequence = cookingSequence;
            DishName = dishName;
        }

        public override NewDish Use(List<IIngredient> ingredients)
        {
            if (ingredients is null || ingredients.Count == 0)
            {
                throw new ArgumentNullException();
            }

            return new NewDish(5, CookIngredients(ingredients), DishName);
        }
    }
}
