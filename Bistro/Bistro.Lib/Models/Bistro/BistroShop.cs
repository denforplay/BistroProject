using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.StorageConditions;
using Bistro.Lib.Models.WorkingStuff;
using System;
using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Bistro.Menu;
using Bistro.Lib.Models.Ingredients.Vegetables;

namespace Bistro.Lib.Models.Bistro
{

    /// <summary>
    /// Represents bistro shop
    /// </summary>
    public sealed class BistroShop
    {
        /// <summary>
        /// Manager, work with orders
        /// </summary>
        public Manager Manager { get; set; }

        /// <summary>
        /// Kitchen, work with ingredients and ingredients handling
        /// </summary>
        public Kitchen Kitchen { get; set; }

        /// <summary>
        /// Cooked dishes
        /// </summary>
        public List<DishBase> ReadyDishes { get; set; }

        /// <summary>
        /// Bistro dishes menu
        /// </summary>
        public BistroMenu Menu { get; set; }

        
        /// <summary>
        /// Bistro shop constructor
        /// </summary>
        /// <param name="kitchen"></param>
        /// <param name="menu"></param>
        public BistroShop(Kitchen kitchen, BistroMenu menu)
        {
            ReadyDishes = new List<DishBase>();
            var ingredients = new List<IIngredient> { new Tomato(5, 5) };
            var dish = new Salad(5, ingredients);
            Manager = new Manager();
            Kitchen = kitchen;
            Menu = menu;
        }

        /// <summary>
        /// Take order method
        /// </summary>
        /// <param name="order">Order</param>
        public void TakeOrder(Order order)
        {
            Manager.TakeOrder(order);
        }

        /// <summary>
        /// Complete order method
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Get frequency products use dictionary
        /// </summary>
        /// <returns></returns>
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

        /// <summary>
        /// Method to get most costable ingredient handlers
        /// </summary>
        /// <param name="fromDate">From date</param>
        /// <param name="toDate">To date</param>
        /// <returns>Dictionaty with type of ingredient handler and max cost for this ingredient handler</returns>
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

        /// <summary>
        /// Get expenses on cooking
        /// </summary>
        /// <param name="fromDate">From order date</param>
        /// <param name="toDate">To order date</param>
        /// <returns>Dictionary with key of dishtype and value of dishcose</returns>
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

        /// <summary>
        /// Find ingredients with current store conditions
        /// </summary>
        /// <param name="storageCondition"></param>
        /// <returns></returns>
        public List<IIngredient> FindIngredients(List<IStorageCondition> storageCondition)
        {
            return Kitchen.IngredientStorage.GetAll().FindAll(i => i.StoreConditions.IsExcept(storageCondition));
        }

        /// <summary>
        /// Sell dish method
        /// </summary>
        /// <param name="dish">Dish to sell</param>
        /// <exception cref="ArgumentNullException">Throw null if there are no such dish</exception>
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
