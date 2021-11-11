using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Recipes
{
    public abstract class RecipeBase<T> where T : DishBase
    {
        protected List<IIngredient> _composition;
        protected Queue<Action> _cookingSequence;
        public RecipeBase()
        {
            _composition = new List<IIngredient>();
            _cookingSequence = new Queue<Action>();
        }
        public IReadOnlyList<IIngredient> Composition => _composition;

        public abstract T Use(List<IIngredient> ingredients);
    }
}
