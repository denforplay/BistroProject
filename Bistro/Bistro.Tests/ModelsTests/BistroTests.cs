using Xunit;
using Bistro.Lib.Models;
using System.Collections.Generic;
using Bistro.Lib.Models.Dishes;
using System;
using System.Linq;
using Bistro.Lib.Models.Bistro;
using Bistro.Lib.Models.Bistro.Capabilities;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Bistro.Conditions;
using Bistro.Lib.Models.StorageConditions;
using Bistro.Lib.Core.Enums;
using Bistro.Lib.Models.Bistro.Storage;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Recipes.SaladRecipes;
using Bistro.Lib.Models.WorkingStuff;
using Bistro.Lib.Models.Bistro.Menu;
using Bistro.Lib.Models.Recipes.Base;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.Ingredients.Meat;

namespace Bistro.Tests.ModelsTests
{
    public sealed class BistroTests
    {
        private StorageConditionsContainer _storageConditions = new StorageConditionsContainer(new Dictionary<Type, List<IStorageCondition>>
        {
            { typeof(TemperatureCondition), new List<IStorageCondition>{new TemperatureCondition(-5, 5)} },
            { typeof(PackageCondition), new List<IStorageCondition>{new PackageCondition(PackageType.ClosedContainer)} },
        });
        
        private ProductionCapabilities _capabilities = new ProductionCapabilities(new Dictionary<Type, int>
        {
            {typeof(Baking), 5},
            {typeof(Slicing), 5},
            {typeof(AddingToDish), 10},
            {typeof(Boiling), 10},
        });

        private BistroMenu _bistroMenu = new BistroMenu(new Dictionary<Type, IRecipe<ProductBase>>
        {
            { typeof(ChickenSaladRecipe), new ChickenSaladRecipe()},
            { typeof(VegetableSaladRecipe), new VegetableSaladRecipe()},
        });

        [Fact]
        public void TestFrequencyProductsUse()
        {
            int expected = 5;
            
            IngredientStorage storage = new IngredientStorage(
                new Dictionary<Type, List<IIngredient>>
                {
                    {typeof(SauсeBase), new List<IIngredient> { new Ketchup(5, 5), } }
                }, _storageConditions);

            Kitchen kitchen = new Kitchen(new Chef(), storage, _capabilities);
            
            BistroShop bistro = new BistroShop(kitchen, _bistroMenu);
            bistro.TakeOrder(new Order(0, new List<Type>
            {
                typeof(VegetableSaladRecipe),
                typeof(VegetableSaladRecipe),
                typeof(VegetableSaladRecipe),
            }));

            bistro.TakeOrder(new Order(1, new List<Type>
            {
                typeof(ChickenSaladRecipe),
                typeof(ChickenSaladRecipe),
            }));

            var productsFrequencies = bistro.GetFrequencyProductsUse();
            Assert.Equal(expected, productsFrequencies.First().Value);
        }


        [Fact]
        public void TestOrderFromDateToDate()
        {
            int expected = 5;

            Manager manager = new Manager();
            manager.TakeOrder(new Order(0, new List<Type>
            {
                typeof(VegetableSaladRecipe),
                typeof(VegetableSaladRecipe),
                typeof(VegetableSaladRecipe),
            }));

            manager.TakeOrder(new Order(1, new List<Type>
            {
                typeof(ChickenSaladRecipe),
                typeof(ChickenSaladRecipe),
            }));

            var productsFrequencies = manager.FindAllOrders(DateTime.MinValue, DateTime.MaxValue);
        }

        [Fact]
        public void TestGetMostExpensiveIngredientHandlers()
        {
            int expected = 4;

            IngredientStorage storage = new IngredientStorage(
                new Dictionary<Type, List<IIngredient>>
                {
                    {typeof(SauсeBase), new List<IIngredient> { new Ketchup(5, 5), } }
                }, _storageConditions);

            Kitchen kitchen = new Kitchen(new Chef(), storage, _capabilities);

            BistroShop bistro = new BistroShop(kitchen, _bistroMenu);
            bistro.TakeOrder(new Order(0, new List<Type>
            {
                typeof(VegetableSaladRecipe),
                typeof(VegetableSaladRecipe),
                typeof(VegetableSaladRecipe),
            }));

            bistro.TakeOrder(new Order(1, new List<Type>
            {
                typeof(ChickenSaladRecipe),
                typeof(ChickenSaladRecipe),
            }));

            var productsFrequencies = bistro.GetMostCostIngredientHandlers(DateTime.MinValue, DateTime.MaxValue);
            Assert.Equal(expected, productsFrequencies.First().Value);
        }

        [Fact]
        public void TestCompleteOrders()
        {
            IngredientStorage storage = new IngredientStorage(
                new Dictionary<Type, List<IIngredient>>
                {
                    {typeof(SauсeBase), new List<IIngredient>
                    {
                        new Ketchup(5, 5), 
                        new Ketchup(5, 5), 
                        new Ketchup(5, 5),
                    } },
                    {typeof(VegetableBase), new List<IIngredient>
                    {
                        new Cucumber(5, 5), 
                        new Tomato(5, 5), 
                        new Cucumber(5, 5), 
                        new Tomato(5, 5), 
                        new Cucumber(5, 5), 
                        new Tomato(5, 5), 
                        new Cucumber(5, 5), 
                        new Tomato(5, 5),
                        new Cucumber(5, 5), 
                        new Tomato(5, 5),
                    } },
                    {typeof(MeatBase), new List<IIngredient>
                    {
                        new Chicken(5, 5), 
                        new Chicken(5, 5),
                    } }
                }, _storageConditions);

            Kitchen kitchen = new Kitchen(new Chef(), storage, _capabilities);

            BistroShop bistro = new BistroShop(kitchen, _bistroMenu);
            bistro.TakeOrder(new Order(0, new List<Type>
            {
                typeof(VegetableSaladRecipe),
                typeof(VegetableSaladRecipe),
                typeof(VegetableSaladRecipe),
            }));

            bistro.TakeOrder(new Order(1, new List<Type>
            {
                typeof(ChickenSaladRecipe),
                typeof(ChickenSaladRecipe),
            }));

            bistro.CompleteOrder();
            bistro.CompleteOrder();
            Assert.True(bistro.Kitchen.IngredientStorage.GetAll().Count == 0);
        }
    }
}
