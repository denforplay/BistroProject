using System;
using System.Collections.Generic;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Meat;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.Recipes.Base;

namespace Bistro.Lib.Models.Recipes.SaladRecipes
{
    public sealed class ChickenSaladRecipe : RecipeBase<Salad>
    {
        public ChickenSaladRecipe()
        {
            Composition = new List<IIngredient>
            {
                new Chicken(5, 5),
                new Tomato(5, 5),
                new Cucumber(5, 5)
            };

            CookingSequence.Enqueue(new Slicing(20, 10, Composition));
            CookingSequence.Enqueue(new AddingToDish(5, 3, Composition));
        }

        public override Salad Use(List<IIngredient> ingredients)
        {
            if (ingredients is null || ingredients.Count == 0)
            {
                throw new ArgumentNullException();
            }

            return new Salad(5, CookIngredients(ingredients));
        }
    }
}
