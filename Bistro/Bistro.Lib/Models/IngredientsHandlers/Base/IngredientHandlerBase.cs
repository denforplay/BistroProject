using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.IngredientsHandlers.Base
{
    public abstract class IngredientHandlerBase : IIngredientsHandler
    {
        private List<IIngredient> _ingredients;

        public IngredientHandlerBase()
        {
            Cost = 0;
            Duration = 0;
            _ingredients = new List<IIngredient>();
        }

        public IngredientHandlerBase(double cost, double duration, List<IIngredient> ingredients)
        {
            Ingredients = ingredients;
            Cost = cost;
            Duration = duration;
        }
        
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
        public double Cost { get; init; }
        public double Duration { get; init; }
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