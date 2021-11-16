﻿using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.IngredientsHandlers
{
    public sealed class Slicing : IngredientHandlerBase
    {
        public Slicing(double cost, double duration, List<IIngredient> ingredients) : base(cost, duration, ingredients)
        {
        }
    }
}
