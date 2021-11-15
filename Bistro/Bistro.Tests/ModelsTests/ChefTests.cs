using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Meat;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.Recipes;
using Bistro.Lib.Models.WorkingStuff;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;
using Bistro.Lib.Models.Recipes.SaladRecipes;
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

            Assert.Equal(32, chef.Cook(new VegetableSaladRecipe(), ingredients).Cost);
        }

        [Fact]
        public void TestCreateNewRecipe()
        {
            Chef chef = new Chef();
         
            List<IIngredient> composition = new List<IIngredient>
            {
                new Cucumber(5, 5),
                new Tomato(5, 5),
                new Chicken(10, 5)
            };

            Queue<IIngredientsHandler> cookingSequence = new Queue<IIngredientsHandler>();
            cookingSequence.Enqueue(new Baking(10, 10, new List<IIngredient>{composition[2]}));
            cookingSequence.Enqueue(new Slicing(5, 5, new List<IIngredient>{composition[0]}));
            cookingSequence.Enqueue(new Slicing(5, 5, new List<IIngredient>{composition[1]}));

            var newRecipe = chef.CreateNewRecipe(composition, cookingSequence, "Chicken with vegetables");
            Assert.True(newRecipe is NewRecipe);
            var dish = chef.Cook(newRecipe, composition);
        }
    }
}
