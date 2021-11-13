using Bistro.Lib.Models;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Meat;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.IngridientsHandlers;
using Bistro.Lib.Models.Recipes;
using JSONLib.Models;
using System.Collections.Generic;
using Xunit;

namespace Bistro.JSONWorker.Tests
{
    public sealed class JSONWorkerTests
    {
        [Fact]
        public void TestWritingIngredient()
        {
            string filepath = @"C:\Test\test.json";
            JsonWorker json = new JsonWorker(filepath);
            IIngredient expectedTomato = new Tomato(20, 20);
            IIngredientsHandler handler = new Slicing(5, 5, expectedTomato);
            json.Serialize(expectedTomato);
            Tomato actualTomato = json.Deserialize<Tomato>();
            Assert.Equal(expectedTomato, actualTomato);
        }

        [Fact]
        public void TestWritingRecipe()
        {
            string filepath = @"C:\Test\test.json";
            JsonWorker json = new JsonWorker(filepath);
            var expectedRecipe = new SaladRecipe();
            json.Serialize(expectedRecipe);
            var actualRecipe = json.Deserialize<SaladRecipe>();
            Assert.Equal(expectedRecipe, actualRecipe);
        }

        [Fact]
        public void TestWritingNewRecipe()
        {
            string filepath = @"C:\Test\test.json";
            JsonWorker json = new JsonWorker(filepath);
            List<IIngredient> composition = new List<IIngredient>()
            {
                new Chicken(10, 10),
                new Ketchup(1, 1)
            };

            Queue<IIngredientsHandler> cookingSequence = new Queue<IIngredientsHandler>();
            cookingSequence.Enqueue(new Baking(10, 10, composition[0]));
            cookingSequence.Enqueue(new AddingToDish(10, 10, composition[1]));
            var expectedRecipe = new NewRecipe(composition, cookingSequence, "Chicken with kechup");
            json.Serialize(expectedRecipe);
            var actualRecipe = json.Deserialize<NewRecipe>();
        }
    }
}
