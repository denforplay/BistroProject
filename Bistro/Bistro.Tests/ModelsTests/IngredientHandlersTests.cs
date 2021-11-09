﻿using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.IngridientsHandlers;
using Xunit;

namespace Bistro.Tests.ModelsTests
{
    public sealed class IngredientHandlersTests
    {
        [Theory]
        [InlineData(5, 5, 5, 10)]
        public void SliceTests(double sliceCost, double sliceDuration, double ingredientCost, double expected)
        {
            IIngredient ingredient = new Cucumber(ingredientCost);
            IIngredientHandler slicer = new Slicing(sliceCost, sliceDuration, ingredient);
            slicer.Handle();
            Assert.Equal(expected, ingredient.Cost);
        }
    }
}