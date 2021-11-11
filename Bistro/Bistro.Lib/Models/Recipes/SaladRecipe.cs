using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.IngridientsHandlers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Models.Recipes
{
    public sealed class SaladRecipe : RecipeBase<Salad>
    {
        public SaladRecipe()
        {
            _composition = new List<IIngredient>
            {
                new Cucumber(5, 5),
                new Tomato(5, 5),
                new Ketchup(5, 5)
            };

            _cookingSequence.Enqueue(new Slicing(5, 5, _composition[0]));
            _cookingSequence.Enqueue(new Slicing(3, 3, _composition[1]));
            _cookingSequence.Enqueue(new AddToDish(4, 4, _composition[2]));
        }

        public override Salad Use(List<IIngredient> ingredients)
        {
            if (ingredients is null || ingredients.Count == 0)
            {
                throw new ArgumentNullException();
            }

            if (_composition.IsExcept(ingredients))
            {
                List<IIngredient> saladIngredients = new List<IIngredient>();
                while (_cookingSequence.Count() > 0)
                {
                    var method = _cookingSequence.Dequeue();
                    var ingredient = ingredients.Find(x => x.Equals(method.Ingredient));
                    method.Ingredient = ingredient;
                    method.Handle();
                    saladIngredients.Add(ingredient);
                    ingredients.Remove(ingredient);
                }

                return new Salad(5, saladIngredients);
            }
            else
            {
                throw new UseRecipeWrongIngredientsException();
            }
        }
    }
}
