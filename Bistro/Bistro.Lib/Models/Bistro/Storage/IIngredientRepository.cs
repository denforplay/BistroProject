using System;
using System.Collections.Generic;
using Bistro.Lib.Core.Interfaces;
using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.Bistro
{
    public interface IIngredientRepository : IRepository<Type, List<IIngredient>>
    {
        List<IIngredient> GetAll();
    }
}