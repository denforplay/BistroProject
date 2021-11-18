using System;
using System.Collections.Generic;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.Recipes.Base;

namespace Bistro.Lib.Models.Recipes.SaladRecipes
{
    /// <summary>
    /// Represents vegetable salad recipe
    /// </summary>
    public sealed class VegetableSaladRecipe : RecipeBase<Salad>
    {
        /// <summary>
        /// Vegetable salad recipe default constructor
        /// </summary>
        public VegetableSaladRecipe()
        {
            Composition = new List<IIngredient>
            {
                new Cucumber(5, 5),
                new Tomato(5, 5),
                new Ketchup(5, 5)
            };

            CookingSequence.Enqueue(new Slicing(5, 5, new List<IIngredient>{Composition[0]}));
            CookingSequence.Enqueue(new Slicing(3, 3,new List<IIngredient>{ Composition[1]}));
            CookingSequence.Enqueue(new AddingToDish(4, 4, new List<IIngredient>{ Composition[2]}));
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
