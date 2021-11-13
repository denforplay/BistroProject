using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngridientsHandlers;
using Bistro.Lib.Models.Recipes;
using Bistro.Lib.Models.StorageConditions;
using Bistro.Lib.Models.WorkingStuff;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Models
{
    public sealed class BistroShop
    {
        private double _profit;
        private Manager _manager;
        private Chef _chief;
        private List<IStorageCondition> _storageConditions;
        private List<DishBase> _readyDishes;
        private List<IIngredient> _ingredients;
        private Dictionary<IIngredientsHandler, int> _productionCapabilities;
        private Dictionary<Type, IRecipe<DishBase>> _bistroRecipes;

        public BistroShop(Dictionary<IIngredientsHandler, int> productionCapabilities)
        {
            _bistroRecipes = new Dictionary<Type, IRecipe<DishBase>>
            {
                { typeof(Salad), new SaladRecipe() },
            };

            _manager = new Manager();
            _productionCapabilities = productionCapabilities;
        }

        public void TakeOrder(Order order)
        {
            _manager.TakeOrder(order);
        }

        public Dictionary<Type, int> GetFrequencyProductsUse()
        {
            var productsFrequency = new Dictionary<Type, int>();

            foreach (var order in _manager.Orders)
                foreach (var dishType in order.DishTypes)
                    foreach (var ingridient in _bistroRecipes[dishType].Composition)
                        if (productsFrequency.TryGetValue(ingridient.GetType(), out _))
                        {
                            productsFrequency[ingridient.GetType()] += 1;
                        }
                        else
                        {
                            productsFrequency.Add(ingridient.GetType(), 1);
                        }

            return productsFrequency.OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
        }

        public List<Order> FindAllOrders(DateTime fromDate, DateTime toDate)
        {
            return _manager.Orders.Where(order => order.OrderTime.CompareTo(fromDate) > 1 && order.OrderTime.CompareTo(toDate) < 1).ToList();
        }

        public List<IIngredient> FindIngredients(List<IStorageCondition> storageCondition)
        {
            return _ingredients.FindAll(i => i.StoreConditions.IsExcept(storageCondition));
        }

        public void SellDish(DishBase dish)
        {
            DishBase findedDish = _readyDishes.Find(x => x.Equals(dish));
            if (findedDish is not null)
            {
                _profit += findedDish.Cost;
                _readyDishes.Remove(findedDish);
            }
            else
            {
                throw new ArgumentNullException(nameof(findedDish), "Dish is not finded");
            }
        }
    }
}
