using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngridientsHandlers;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Recipes
{
    public abstract class RecipeBase<T> : IRecipe<T> where T : DishBase
    {
        protected List<IIngredient> _composition;
        protected Queue<IIngredientsHandler> _cookingSequence;

        public IReadOnlyList<IIngredient> Composition => _composition;

        public RecipeBase()
        {
            _composition = new List<IIngredient>();
            _cookingSequence = new Queue<IIngredientsHandler>();
        }


        public abstract T Use(List<IIngredient> ingredients);

        public override bool Equals(object obj)
        {
            if (obj is RecipeBase<T> otherRecipe)
            {
                return _composition.IsEqual(otherRecipe.Composition)
                    && _cookingSequence.Equals(_cookingSequence);
            }

            return false;
        }
    }
}