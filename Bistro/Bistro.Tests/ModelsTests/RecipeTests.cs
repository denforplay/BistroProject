using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.Recipes;
using System;
using System.Collections.Generic;
using Xunit;

namespace Bistro.Tests.ModelsTests
{
    public sealed class RecipeTests
    {
        [Fact]
        public void TestUseRecipe_NullIngredients_ThrowsArgumentNullException()
        {
            RecipeBase<Salad> recipe = new SaladRecipe();
            Assert.Throws<ArgumentNullException>(() => recipe.Use(null));
        }

        [Fact]
        public void TestUseRecipe_EmptyIngredients_ThrowsArgumentNullException()
        {
            RecipeBase<Salad> recipe = new SaladRecipe();
            Assert.Throws<ArgumentNullException>(() => recipe.Use(new List<IIngredient>()));
        }

        [Fact]
        public void TestUseRecipe_InvalidIngredients_ThrowsUseRecipeWrongIngredientsException()
        {
            RecipeBase<Salad> recipe = new SaladRecipe();
            List<IIngredient> ingredients = new List<IIngredient>()
            {
                new Cucumber(5, 5),
                new Cucumber(5, 5),
                new Cucumber(5, 5)
            };

            Assert.Throws<UseRecipeWrongIngredientsException>(() => recipe.Use(ingredients));
        }


        [Fact]
        public void TestUseRecipe_ValidIngredientsInvalidWeight_ThrowsUseRecipeWrongIngredientsException()
        {
            RecipeBase<Salad> recipe = new SaladRecipe();
            List<IIngredient> ingredients = new List<IIngredient>()
            {
                new Cucumber(5, 1),
                new Ketchup(5, 5),
                new Tomato(5, 5)
            };

            Assert.Throws<UseRecipeWrongIngredientsException>(() => recipe.Use(ingredients));
        }

        [Theory]
        [InlineData(5, 5, 5, 32)]
        [InlineData(10, 10, 10, 47)]
        public void TestUseRecipe_ValidIngredients_ThrowsUseRecipeWrongIngredientsException(double cucumberCost, double tomatoCost, double ketchupCost, double expected)
        {
            RecipeBase<Salad> recipe = new SaladRecipe();
            List<IIngredient> ingredients = new List<IIngredient>()
            {
                new Cucumber(cucumberCost, 5),
                new Tomato(tomatoCost, 5),
                new Ketchup(ketchupCost, 5)
            };

            Salad salad = recipe.Use(ingredients);
            Assert.Equal(expected, salad.Cost);
            Assert.True(ingredients.Count == 0);
        }
    }
}
