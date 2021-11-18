using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Meat;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.Recipes;
using JSONLib.Models;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;
using Bistro.Lib.Models.Recipes.SaladRecipes;
using Xunit;
using Bistro.Lib.Models.Bistro;
using Bistro.Lib.Models.WorkingStuff;
using Bistro.Lib.Models.Bistro.Storage;
using System;
using Bistro.Lib.Models.Bistro.Conditions;
using Bistro.Lib.Models.StorageConditions;
using Bistro.Lib.Core.Enums;
using Bistro.Lib.Models.Bistro.Capabilities;
using Bistro.Lib.Models.Bistro.Menu;
using Bistro.Lib.Models.Recipes.Base;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models;

namespace Bistro.JSONWorker.Tests
{
    public sealed class JSONWorkerTests
    {
        [Fact]
        public void TestWritingIngredient()
        {
            string filepath = @"C:\Test\test.json";
            ISerializer json = new JsonSerializer(filepath);
            IIngredient expectedTomato = new Tomato(20, 20);
            IIngredientsHandler handler = new Slicing(5, 5, new List<IIngredient> { expectedTomato });
            json.Serialize(expectedTomato);
            Tomato actualTomato = json.Deserialize<Tomato>();
            Assert.Equal(expectedTomato, actualTomato);
        }

        [Fact]
        public void TestWritingRecipe()
        {
            string filepath = @"C:\Test\test.json";
            ISerializer json = new JsonSerializer(filepath);
            var expectedRecipe = new VegetableSaladRecipe();
            json.Serialize(expectedRecipe);
            var actualRecipe = json.Deserialize<VegetableSaladRecipe>();
            Assert.True(expectedRecipe.Equals(actualRecipe));
        }

        [Fact]
        public void TestWritingNewRecipe()
        {
            string filepath = @"C:\Test\test.json";
            ISerializer json = new JsonSerializer(filepath);
            List<IIngredient> composition = new List<IIngredient>()
            {
                new Chicken(10, 10),
                new Ketchup(1, 1)
            };

            Queue<IIngredientsHandler> cookingSequence = new Queue<IIngredientsHandler>();
            cookingSequence.Enqueue(new Baking(10, 10, new List<IIngredient> { composition[0] }));
            cookingSequence.Enqueue(new AddingToDish(10, 10, new List<IIngredient> { composition[1] }));
            var expectedRecipe = new NewRecipe(composition, cookingSequence, "Chicken with kechup");
            json.Serialize(expectedRecipe);
            var actualRecipe = json.Deserialize<NewRecipe>();
            Assert.True(actualRecipe.Equals(expectedRecipe));
        }

        [Fact]
        public void TestWritingKitchen()
        {
            string filepath = @"C:\Test\test.json";
            ISerializer json = new JsonSerializer(filepath);

            StorageConditionsContainer _storageConditions = new StorageConditionsContainer(new Dictionary<Type, List<IStorageCondition>>
            {
                { typeof(TemperatureCondition), new List<IStorageCondition>{new TemperatureCondition(-5, 5)} },
                { typeof(PackageCondition), new List<IStorageCondition>{new PackageCondition(PackageType.ClosedContainer)} },
            });

            ProductionCapabilities capabilities = new ProductionCapabilities(new Dictionary<Type, int>
            {
            {typeof(Baking), 5},
            {typeof(Slicing), 5},
            {typeof(AddingToDish), 10},
            {typeof(Boiling), 10},
            });

            IIngredientRepository storage = new IngredientStorage(
                    new Dictionary<Type, List<IIngredient>>
                    {
                    {typeof(SauсeBase), new List<IIngredient> { new Ketchup(5, 5), } }
                    }, _storageConditions);

            Kitchen kitchen = new Kitchen(new Chef(), storage, capabilities);

            json.Serialize(kitchen);
            var actualKitchen = json.Deserialize<Kitchen>();
        }

        [Fact]
        public void TestWritingBistro()
        {
            string filepath = @"C:\Test\test.json";
            ISerializer json = new JsonSerializer(filepath);

            StorageConditionsContainer _storageConditions = new StorageConditionsContainer(new Dictionary<Type, List<IStorageCondition>>
            {
                { typeof(TemperatureCondition), new List<IStorageCondition>{new TemperatureCondition(-5, 5)} },
                { typeof(PackageCondition), new List<IStorageCondition>{new PackageCondition(PackageType.ClosedContainer)} },
            });

            ProductionCapabilities capabilities = new ProductionCapabilities(new Dictionary<Type, int>
            {
            {typeof(Baking), 5},
            {typeof(Slicing), 5},
            {typeof(AddingToDish), 10},
            {typeof(Boiling), 10},
            });

            IIngredientRepository storage = new IngredientStorage(
                    new Dictionary<Type, List<IIngredient>>
                    {
                    {typeof(SauсeBase), new List<IIngredient> { new Ketchup(5, 5), } }
                    }, _storageConditions);

            BistroMenu menu = new BistroMenu(new Dictionary<Type, IRecipe<ProductBase>>
            {
                {typeof(VegetableSaladRecipe), new VegetableSaladRecipe() },

            });

            Kitchen kitchen = new Kitchen(new Chef(), storage, capabilities);
            BistroShop bistroShop = new BistroShop(kitchen, menu);
            bistroShop.TakeOrder(new Order(0, new List<Type> { typeof(VegetableSaladRecipe) }));
            json.Serialize(bistroShop);
            var actualBistro = json.Deserialize<BistroShop>();
        }
    }
}