using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.Recipes.Base
{
    public abstract class RecipeBase<T> : IRecipe<T> where T : DishBase
    {
        public List<IIngredient> Composition { get; set; }
        public Queue<IIngredientsHandler> CookingSequence { get; set; }

        public RecipeBase()
        {
            Composition = new List<IIngredient>();
            CookingSequence = new Queue<IIngredientsHandler>();
        }

        protected List<IIngredient> CookIngredients(List<IIngredient> ingredients)
        {
            if (Composition.IsExcept(ingredients))
            {
                List<IIngredient> saladIngredients = new List<IIngredient>();
                while (CookingSequence.Any())
                {
                    var method = CookingSequence.Dequeue();
                    var findedIngredients = ingredients.FindList(method.Ingredients);
                    if (findedIngredients is null)
                        throw new UseRecipeWrongIngredientsException();
                    method.Ingredients = findedIngredients;
                    method.Handle();
                    findedIngredients.ForEach(x => saladIngredients.Add(x));
                    findedIngredients.ForEach(x => ingredients.Remove(x));
                }

                return saladIngredients;
            }

            throw new UseRecipeWrongIngredientsException();
        }

        public abstract T Use(List<IIngredient> ingredients);

        public override bool Equals(object obj)
        {
            if (obj is RecipeBase<T> otherRecipe)
            {
                return Composition.IsEqual(otherRecipe.Composition)
                    && CookingSequence.IsEqual(otherRecipe.CookingSequence);
            }

            return false;
        }
    }
}