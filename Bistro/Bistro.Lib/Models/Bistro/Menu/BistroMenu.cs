using System;
using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Recipes.Base;

namespace Bistro.Lib.Models.Bistro.Menu
{
    public sealed class BistroMenu : IMenuRepository
    {
        public BistroMenu()
        {
            Menu = new Dictionary<Type, IRecipe<DishBase>>();
        }

        public BistroMenu(Dictionary<Type, IRecipe<DishBase>> menu)
        {
            Menu = menu;
        }

        public Dictionary<Type, IRecipe<DishBase>> Menu { get; init; }

        public IRecipe<DishBase> GetByKey(Type key)
        {
            return Menu[key];
        }

        public void Add(Type dishType, IRecipe<DishBase> dishRecipe)
        {
            if (Menu.TryGetValue(dishType, out IRecipe<DishBase> _))
            {
                return;
            }

            Menu.Add(dishType, dishRecipe);
        }

        public void Delete(Type dishType, IRecipe<DishBase> dishRecipe)
        {
            if (Menu.TryGetValue(dishType, out IRecipe<DishBase> _))
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
