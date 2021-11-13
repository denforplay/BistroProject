﻿using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.IngridientsHandlers
{
    public sealed class Slicing : IIngredientsHandler
    {
        public List<IIngredient> Ingredients { get; set; }
        public double Cost { get; init; }
        public double Duration { get; init; }

        public Slicing(double cost, double duration, List<IIngredient> ingredients)
        {
            Cost = cost;
            Duration = duration;
            Ingredients = ingredients;
        }

        public void Handle()
        {
            if (Ingredients.TrueForAll(x => x.IngredientHandlers.Any(y => y.GetType() == GetType())))
            {
                Ingredients.ForEach(i => i.Cost += Cost);
            }
            else
            {
                throw new InapplicableHandlerException(this, Ingredients[0]);
            }
        }
    }
}
