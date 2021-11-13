using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngridientsHandlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Models.Recipes
{
    public sealed class NewRecipe : RecipeBase<NewDish>
    {
        private string _dishName;

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

            _composition = composition;
            _cookingSequence = cookingSequence;
            _dishName = dishName;
        }

        public override NewDish Use(List<IIngredient> ingredients)
        {
            if (ingredients is null || ingredients.Count == 0)
            {
                throw new ArgumentNullException();
            }

            if (_composition.IsExcept(ingredients))
            {
                while (_cookingSequence.Count() > 0)
                {
                    _cookingSequence.Dequeue().Handle();
                }

                return new NewDish(5, _composition, _dishName);
            }
            else
            {
                throw new UseRecipeWrongIngredientsException();
            }
        }
    }
}
