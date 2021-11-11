using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngridientsHandlers;
using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Recipes
{
    public abstract class RecipeBase<T> where T : DishBase
    {
        protected List<IIngredient> _composition;
        protected Queue<IIngredientHandler> _cookingSequence;
        public RecipeBase()
        {
            _composition = new List<IIngredient>();
            _cookingSequence = new Queue<IIngredientHandler>();
        }
        public IReadOnlyList<IIngredient> Composition => _composition;

        public abstract T Use(List<IIngredient> ingredients);
    }
}
