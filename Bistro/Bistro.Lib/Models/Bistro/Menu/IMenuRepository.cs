using Bistro.Lib.Core.Interfaces;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Recipes.Base;
using System;

namespace Bistro.Lib.Models.Bistro.Menu
{
    public interface IMenuRepository : IRepository<Type, IRecipe<DishBase>>
    {
    }
}
