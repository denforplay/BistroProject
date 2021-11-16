using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Meat;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;
using Xunit;

namespace Bistro.Tests.ModelsTests
{
    public sealed class IngredientHandlersTests
    {
        [Fact]
        public void SlicingTest_IncompatibleIngredient_ThrowInapplicableHandlerException()
        {
            IIngredient ingredient = new Ketchup(5, 1);
            Assert.Throws<InapplicableHandlerException>(() => new Slicing(5, 5, new List<IIngredient>{ingredient}));
        }
        
        [Theory]
        [InlineData(5, 5, 5, 10)]
        public void SlicingTest_SingleIngredient_ReturnsTrue(double cost, double duration, double ingredientCost, double expected)
        {
            IIngredient ingredient = new Cucumber(ingredientCost, 1);
            IIngredientsHandler slicer = new Slicing(cost, duration, new List<IIngredient>{ingredient});
            slicer.Handle();
            Assert.Equal(expected, ingredient.Cost);
        }

        [Fact]
        public void SlicingTest_MultipleIngredient_ThrowInapplicableHandlerException()
        {
            List<IIngredient> ingredients = new List<IIngredient>
            {
                new Tomato(5, 5),
                new Chicken(5, 5),
                new Ketchup(5, 5),
                new Potato(5, 5)
            };

            Assert.Throws<InapplicableHandlerException>(() => new Slicing(5, 5, ingredients));
        }

        [Fact]
        public void SlicingTest_MultipleIngredient_ReturnsTrue()
        {
            List<IIngredient> ingredients = new List<IIngredient>
            {
                new Tomato(5, 5),
                new Chicken(5, 5),
                new Potato(5, 5)
            };

            IIngredientsHandler slicer = new Slicing(5, 5, ingredients);
            slicer.Handle();
            Assert.Equal(30, ingredients.Sum(x => x.Cost));
        }
    }
}
