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

            _cookingSequence.Enqueue(new Slicing(5, 5, new List<IIngredient>{_composition[0]}));
            _cookingSequence.Enqueue(new Slicing(3, 3,new List<IIngredient>{_composition[1]}));
            _cookingSequence.Enqueue(new AddingToDish(4, 4, new List<IIngredient>{_composition[2]}));
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
                while (_cookingSequence.Any())
                {
                    var method = _cookingSequence.Dequeue();
                    var findedIngredients = ingredients.FindList(method.Ingredients);
                    if (findedIngredients is null)
                        throw new UseRecipeWrongIngredientsException();
                    method.Ingredients = findedIngredients;
                    method.Handle();
                    findedIngredients.ForEach(x => saladIngredients.Add(x));
                    findedIngredients.ForEach(x => ingredients.Remove(x));
                }

                return new Salad(5, saladIngredients);
            }

            throw new UseRecipeWrongIngredientsException();
        }
    }
}
