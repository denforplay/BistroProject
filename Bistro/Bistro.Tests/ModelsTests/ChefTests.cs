using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Meat;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.IngridientsHandlers;
using Bistro.Lib.Models.Recipes;
using Bistro.Lib.Models.WorkingStuff;
using System;
using System.Collections.Generic;
using Xunit;

namespace Bistro.Tests.ModelsTests
{
    public sealed class ChefTests
    {
        [Fact]
        public void TestCook()
        {
            Chef chef = new Chef();
            List<IIngredient> ingredients = new List<IIngredient>()
            {
                new Cucumber(5, 5),
                new Ketchup(5, 5),
                new Tomato(5, 5)
            };

            Assert.Equal(32, chef.Cook(new SaladRecipe(), ingredients).Cost);
        }

        [Fact]
        public void TestCreateNewRecipe()
        {
            Chef chef = new Chef();
            List<IIngredient> ingredients = new List<IIngredient>()
            {
                new Cucumber(5, 5),
                new Ketchup(5, 5),
                new Tomato(5, 5)
            };

            List<IIngredient> composition = new List<IIngredient>
            {
                new Cucumber(5, 5),
                new Tomato(5, 5),
                new Chicken(10, 5)
            };

            Queue<Action> cookingSequence = new Queue<Action>();
            cookingSequence.Enqueue(() => new Baking(10, 10, composition[0]));
            cookingSequence.Enqueue(() => new Slicing(5, 5, composition[1]));
            cookingSequence.Enqueue(() => new Slicing(5, 5, composition[2]));

            Assert.True(chef.CreateNewRecipe(composition, cookingSequence, "Chicken with vegetables") is NewRecipe);
        }
    }
}
