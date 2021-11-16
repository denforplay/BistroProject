﻿using Xunit;
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

namespace Bistro.Tests.ModelsTests
{
    public sealed class BistroTests
    {
        private StorageConditionsContainer _storageConditions = new StorageConditionsContainer(new Dictionary<Type, List<IStorageCondition>>
        {
            { typeof(TemperatureCondition), new List<IStorageCondition>{new TemperatureCondition(-5, 5)} },
            { typeof(PackageCondition), new List<IStorageCondition>{new PackageCondition(PackageType.ClosedContainer)} },
        });
        
        private ProductionCapabilities capabilities = new ProductionCapabilities(new Dictionary<Type, int>
        {
            {typeof(Baking), 5},
            {typeof(Slicing), 5},
            {typeof(AddingToDish), 10},
            {typeof(Boiling), 10},
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
            
            BistroShop bistro = new BistroShop(storage, capabilities);
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
    }
}
