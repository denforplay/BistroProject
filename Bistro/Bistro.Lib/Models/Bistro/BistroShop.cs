using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.StorageConditions;
using Bistro.Lib.Models.WorkingStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Interfaces;
using Bistro.Lib.Models.Bistro.Capabilities;
using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Bistro.Menu;
using Bistro.Lib.Models.Bistro.Storage;
using Bistro.Lib.Models.Recipes.SaladRecipes;

namespace Bistro.Lib.Models.Bistro
{
    public sealed class BistroShop
    {
        private Manager _manager;
        private Chef _chief;
        private IngredientStorage _storage;
        private List<DishBase> _readyDishes;
        private BistroMenu _menu;

        public BistroShop(IngredientStorage storage, ProductionCapabilities productionCapabilities)
        {
            _storage = storage;
            _menu = new BistroMenu(new Dictionary<Type, Recipes.Base.IRecipe<DishBase>>
            {
                { typeof(VegetableSaladRecipe), new VegetableSaladRecipe() },
                { typeof(ChickenSaladRecipe), new ChickenSaladRecipe() }
            });
            _manager = new Manager();
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
                    foreach (var ingridient in _menu.GetByKey(dishType).Composition)
                        if (productsFrequency.TryGetValue(ingridient.GetType(), out _))
                        {
                            productsFrequency[ingridient.GetType()] += 1;
                        }
                        else
                        {
                            productsFrequency.Add(ingridient.GetType(), 1);
                        }

            return productsFrequency.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
        }

        public Dictionary<Type, double> GetMostCostIngredientHandlers(DateTime fromDate, DateTime toDate)
        {
            var expensesOnIngredientHandlers = new Dictionary<Type, double>();

            foreach(var order in FindAllOrders(fromDate, toDate))
                foreach(var dishtype in order.DishTypes)
                {
                    _menu.GetByKey(dishtype).CookingSequence.ToList().ForEach(x =>
                    {
                        if (expensesOnIngredientHandlers.TryGetValue(x.GetType(), out double value))
                        {
                            if (value < x.Duration)
                                expensesOnIngredientHandlers[x.GetType()] = value;
                        }
                        else
                            expensesOnIngredientHandlers.Add(x.GetType(), x.Duration);
                    });
                }

            return expensesOnIngredientHandlers.OrderBy(x => x.Value).ToDictionary(x => x.Key, y => y.Value);
        }

        public Dictionary<Type, double> GetExpensesOnCooking(DateTime fromDate, DateTime toDate)
        {
            var expensesOnCooking = new Dictionary<Type, double>();
            foreach (var order in FindAllOrders(fromDate, toDate))
                foreach (var dishtype in order.DishTypes)
                {
                    double dishCost = _menu.GetByKey(dishtype).CookingSequence.ToList().Sum(x => x.Duration);
                    if (expensesOnCooking.TryGetValue(dishtype, out double _))
                    {
                        expensesOnCooking[dishtype] += dishCost;
                    }
                }

            return expensesOnCooking;
        }

        public List<Order> FindAllOrders(DateTime fromDate, DateTime toDate)
        {
            return _manager.Orders.Where(order => order.OrderTime.CompareTo(fromDate) > 1 && order.OrderTime.CompareTo(toDate) < 1).ToList();
        }

        public List<IIngredient> FindIngredients(List<IStorageCondition> storageCondition)
        {
            return _storage.GetAll().FindAll(i => i.StoreConditions.IsExcept(storageCondition));
        }

        public void SellDish(DishBase dish)
        {
            DishBase findedDish = _readyDishes.Find(x => x.Equals(dish));
            if (findedDish is not null)
            {
                //_profit += findedDish.Cost;
                _readyDishes.Remove(findedDish);
            }
            else
            {
                throw new ArgumentNullException(nameof(findedDish), "Dish is not finded");
            }
        }
    }
}
