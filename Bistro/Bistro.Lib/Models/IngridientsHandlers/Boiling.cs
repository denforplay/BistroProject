﻿using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;

namespace Bistro.Lib.Models.IngridientsHandlers
{
    public sealed class Boiling : IIngredientsHandler
    {
        public List<IIngredient> Ingredients { get; set; }
        public double Cost { get; init; }
        public double Duration { get; init; }

        public Boiling(double cost, double duration, List<IIngredient> ingredients)
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
