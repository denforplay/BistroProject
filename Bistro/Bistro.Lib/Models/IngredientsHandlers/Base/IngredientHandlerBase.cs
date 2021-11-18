using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.IngredientsHandlers.Base
{
    /// <summary>
    /// Represents base ingredient handler fuctionality
    /// </summary>
    public abstract class IngredientHandlerBase : IIngredientsHandler
    {
        private List<IIngredient> _ingredients;

        /// <summary>
        /// Ingredient handler default constructor
        /// </summary>
        public IngredientHandlerBase()
        {
            Cost = 0;
            Duration = 0;
            _ingredients = new List<IIngredient>();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cost"></param>
        /// <param name="duration"></param>
        /// <param name="ingredients"></param>
        public IngredientHandlerBase(double cost, double duration, List<IIngredient> ingredients)
        {
            Ingredients = ingredients;
            Cost = cost;
            Duration = duration;
        }
        
        /// <summary>
        /// List of ingredients to handle property
        /// </summary>
        public List<IIngredient> Ingredients
        {
            get => _ingredients;
            set
            {
                if (value.TrueForAll(x => x.IngredientHandlers.Any(y => y.GetType() == GetType())))
                {
                    _ingredients = value;
                }
                else
                {
                    throw new InapplicableHandlerException(this, value[0]);
                }
            }
        }

        /// <summary>
        /// Handler cost
        /// </summary>
        public double Cost { get; init; }

        /// <summary>
        /// Handler duration
        /// </summary>
        public double Duration { get; init; }

        /// <summary>
        /// Handle operation
        /// </summary>
        public virtual void Handle()
        {
            Ingredients.ForEach(i => i.Cost += Cost);
        }

        public override int GetHashCode()
        {
            int hash = 1222;
            hash += 44 * Duration.GetHashCode();
            hash += 44 * Cost.GetHashCode();
            _ingredients.ForEach(x => hash += 33 * x.GetHashCode());
            return hash;
        }

        public override bool Equals(object obj)
        {
            if (obj is IngredientHandlerBase ingredientHandler)
            {
                return GetType() == ingredientHandler.GetType()
                    && Duration == ingredientHandler.Duration;
            }

            return false;
        }

        public override string ToString()
        {
            return $"{GetType().Name}";
        }
    }
}