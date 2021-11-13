using Xunit;
using Bistro.Lib.Models;
using System.Collections.Generic;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngridientsHandlers;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Recipes;
using System;

namespace Bistro.Tests.ModelsTests
{
    public sealed class BistroTests
    {
        [Fact]
        public void TestFrequencyProductsUse()
        {
            BistroShop bistro = new BistroShop(new Dictionary<IIngredientsHandler, int>
            {
                { new Baking(10, 10, null), 5 },
            });
            bistro.TakeOrder(new Order(0, new List<Type>
            {
                typeof(Salad),
            }));

            var test = bistro.GetFrequencyProductsUse();
        }
    }
}
