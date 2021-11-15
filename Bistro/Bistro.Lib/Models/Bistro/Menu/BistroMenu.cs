using Bistro.Lib.Models.Dishes;
using System;
using System.Collections.Generic;
using Bistro.Lib.Models.Recipes.Base;
using Bistro.Lib.Models.Bistro.Menu;
namespace Bistro.Lib.Models.Bistro
{
    public sealed class BistroMenu : IMenuRepository
    {
        private Dictionary<Type, IRecipe<DishBase>> _menu;

        public BistroMenu()
        {
            _menu = new Dictionary<Type, IRecipe<DishBase>>();
        }

        public BistroMenu(Dictionary<Type, IRecipe<DishBase>> menu)
        {
            _menu = menu;
        }

        public IRecipe<DishBase> GetByKey(Type key)
        {
            return _menu[key];
        }

        public void Add(Type dishType, IRecipe<DishBase> dishRecipe)
        {
            if (_menu.TryGetValue(dishType, out IRecipe<DishBase> recipe))
            {
                return;
            }

            _menu.Add(dishType, dishRecipe);
        }

        public void Delete(Type dishType, IRecipe<DishBase> dishRecipe)
        {
            if (_menu.TryGetValue(dishType, out IRecipe<DishBase> recipe))
            {
                return;
            }

            _menu.Remove(dishType);
        }


    }
}
