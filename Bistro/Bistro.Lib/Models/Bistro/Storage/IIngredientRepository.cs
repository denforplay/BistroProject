using System;
using System.Collections.Generic;
using Bistro.Lib.Core.Interfaces;
using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.Bistro.Storage
{
    /// <summary>
    /// Provides ingredients data storage functionality
    /// </summary>
    public interface IIngredientRepository : IRepository<Type, List<IIngredient>>
    {
        /// <summary>
        /// Method returns all ingredients from storage
        /// </summary>
        /// <returns>All ingredients from storage</returns>
        List<IIngredient> GetAll();
    }
}