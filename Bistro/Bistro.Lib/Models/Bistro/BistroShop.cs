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
using Bistro.Lib.Models.Ingredients.Vegetables;

namespace Bistro.Lib.Models.Bistro
{
    public sealed class BistroShop
    {
        public Manager Manager { get; set; }
        public Kitchen Kitchen { get; set; }
        public List<DishBase> ReadyDishes { get; set; }
        public BistroMenu Menu { get; set; }

        public BistroShop(Kitchen kitchen, BistroMenu menu)
        {
            ReadyDishes = new List<DishBase>();
            var ingredients = new List<IIngredient> { new Tomato(5, 5) };
            var dish = new Salad(5, ingredients);
            Manager = new Manager();
            Kitchen = kitchen;
            Menu = menu;
        }

        public void TakeOrder(Order order)
        {
            Manager.TakeOrder(order);
        }

        public List<DishBase> CompleteOrder()
        {
            Manager.Orders.Last();
            List<DishBase> cookedDishes = new List<DishBase>();
            foreach(var dishType in Manager.Orders.Last().DishTypes)
            {
                cookedDishes.Add(Kitchen.CookDish(Menu.GetByKey(dishType)));
            }

            ReadyDishes.AddRange(cookedDishes);
            Manager.Orders.RemoveAt(Manager.Orders.Count() - 1);
            return cookedDishes;
        }

        public Dictionary<Type, int> GetFrequencyProductsUse()
        {
            var productsFrequency = new Dictionary<Type, int>();

            foreach (var order in Manager.Orders)
                foreach (var dishType in order.DishTypes)
                    foreach (var ingridient in Menu.GetByKey(dishType).Composition)
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

            foreach(var order in Manager.FindAllOrders(fromDate, toDate))
                foreach(var dishtype in order.DishTypes)
                {
                    Menu.GetByKey(dishtype).CookingSequence.ToList().ForEach(x =>
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
            foreach (var order in Manager.FindAllOrders(fromDate, toDate))
                foreach (var dishtype in order.DishTypes)
                {
                    double dishCost = Menu.GetByKey(dishtype).CookingSequence.ToList().Sum(x => x.Duration);
                    if (expensesOnCooking.TryGetValue(dishtype, out double _))
                    {
                        expensesOnCooking[dishtype] += dishCost;
                    }
                }

            return expensesOnCooking;
        }


        public List<IIngredient> FindIngredients(List<IStorageCondition> storageCondition)
        {
            return Kitchen.IngredientStorage.GetAll().FindAll(i => i.StoreConditions.IsExcept(storageCondition));
        }

        public void SellDish(DishBase dish)
        {
            DishBase findedDish = ReadyDishes.Find(x => x.Equals(dish));
            if (findedDish is not null)
            {
                //_profit += findedDish.Cost;
                ReadyDishes.Remove(findedDish);
            }
            else
            {
                throw new ArgumentNullException(nameof(findedDish), "Dish is not finded");
            }
        }
    }
}
