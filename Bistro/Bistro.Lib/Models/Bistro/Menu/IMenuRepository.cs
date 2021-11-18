using Bistro.Lib.Core.Interfaces;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Recipes.Base;
using System;

namespace Bistro.Lib.Models.Bistro.Menu
{
    /// <summary>
    /// Provides menu data storage functionality
    /// </summary>
    public interface IMenuRepository : IRepository<Type, IRecipe<ProductBase>>
    {
    }
}
