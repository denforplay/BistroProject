using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Models.Dishes
{
    /// <summary>
    /// Represents base product
    /// </summary>
    public abstract class ProductBase
    {
        private List<IIngredient> _ingredients;
        private double _cost;

        /// <summary>
        /// Dish base constructor
        /// </summary>
        public ProductBase()
        {
            _ingredients = new List<IIngredient>();
        }
        
        /// <summary>
        /// Dish constructor
        /// </summary>
        /// <param name="productCost"></param>
        /// <param name="ingredients"></param>
        public ProductBase(double productCost, List<IIngredient> ingredients)
        {
            _ingredients = ingredients;
            _cost = productCost + ingredients.Sum(x => x.Cost);
        }

        /// <summary>
        /// Dish cost
        /// </summary>
        public double Cost => _cost;
        
        /// <summary>
        /// Dish composition
        /// </summary>
        public IReadOnlyList<IIngredient> Ingredients;

        public override bool Equals(object obj)
        {
            if (obj is ProductBase dish)
            {
                return dish._cost == _cost
                    && _ingredients.IsEqual(dish._ingredients);
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1441;
            hash += _cost.GetHashCode();
            hash += _ingredients.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with cost {_cost}"; 
        }
    }
}