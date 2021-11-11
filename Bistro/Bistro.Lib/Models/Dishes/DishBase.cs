using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Models.Dishes
{
    public abstract class DishBase
    {
        private List<IIngredient> _ingredients;
        private double _cost;
      
        public DishBase(double dishCost, List<IIngredient> ingredients)
        {
            _ingredients = ingredients;
            _cost = dishCost + ingredients.Sum(x => x.Cost);
        }

        public double Cost => _cost;
        public IReadOnlyList<IIngredient> Ingredients;

        public override bool Equals(object obj)
        {
            if (obj is DishBase dish)
            {
                return dish._cost == _cost
                    && _ingredients.IsEqual(dish._ingredients);
            }

            return false;
        }
    }
}