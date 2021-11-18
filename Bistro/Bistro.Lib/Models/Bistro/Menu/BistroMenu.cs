using System;
using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Recipes.Base;

namespace Bistro.Lib.Models.Bistro.Menu
{
    /// <summary>
    /// Represent bistro dishes menu
    /// </summary>
    public sealed class BistroMenu : IMenuRepository
    {
        /// <summary>
        /// Bistro menu constructor
        /// </summary>
        public BistroMenu()
        {
            Menu = new Dictionary<Type, IRecipe<ProductBase>>();
        }

        /// <summary>
        /// Bustro menu constructor
        /// </summary>
        /// <param name="menu">Bistro menu</param>
        public BistroMenu(Dictionary<Type, IRecipe<ProductBase>> menu)
        {
            Menu = menu;
        }

        /// <summary>
        /// Dish menu
        /// </summary>
        public Dictionary<Type, IRecipe<ProductBase>> Menu { get; init; }

        public IRecipe<ProductBase> GetByKey(Type key)
        {
            return Menu[key];
        }

        public void Add(Type dishType, IRecipe<ProductBase> dishRecipe)
        {
            if (Menu.TryGetValue(dishType, out IRecipe<ProductBase> _))
            {
                return;
            }

            Menu.Add(dishType, dishRecipe);
        }

        public void Delete(Type dishType, IRecipe<ProductBase> dishRecipe)
        {
            if (Menu.TryGetValue(dishType, out IRecipe<ProductBase> _))
            {
                return;
            }

            Menu.Remove(dishType);
        }

        public override int GetHashCode()
        {
            int hash = 1728;
            foreach(var value in Menu.Values)
            {
                hash += value.GetHashCode();
            }

            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj is BistroMenu otherMenu)
            {
                return Enumerable.SequenceEqual(Menu, otherMenu.Menu);
            }

            return false;
        }

        public override string ToString()
        {
            return "Bistro menu";
        }
    }
}
