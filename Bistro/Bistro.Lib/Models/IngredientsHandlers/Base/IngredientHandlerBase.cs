using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.IngredientsHandlers.Base
{
    public abstract class IngredientHandlerBase : IIngredientsHandler
    {
        private List<IIngredient> _ingredients;

        public IngredientHandlerBase(double cost, double duration, List<IIngredient> ingredients)
        {
            if (ingredients is not null)
                Ingredients = ingredients;
            
            Cost = cost;
            Duration = duration;
        }
        
        public List<IIngredient> Ingredients { 
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
            }}
        public double Cost { get; init; }
        public double Duration { get; init; }
        public virtual void Handle()
        {
            Ingredients.ForEach(i => i.Cost += Cost);
        }
    }
}