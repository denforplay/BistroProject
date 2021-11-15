using System.Collections.Generic;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;
using Xunit;

namespace Bistro.Tests.ModelsTests
{
    public sealed class IngredientHandlersTests
    {
        [Theory]
        [InlineData(5, 5, 5, 10)]
        public void SliceTests(double sliceCost, double sliceDuration, double ingredientCost, double expected)
        {
            IIngredient ingredient = new Cucumber(ingredientCost, 1);
            IIngredientsHandler slicer = new Slicing(sliceCost, sliceDuration, new List<IIngredient>{ingredient});
            slicer.Handle();
            Assert.Equal(expected, ingredient.Cost);
        }
    }
}
