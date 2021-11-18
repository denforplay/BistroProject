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
    /// <summary>
    /// Represents recipe base fuctionality
    /// </summary>
    /// <typeparam name="T">Type of cooking dish</typeparam>
    public abstract class RecipeBase<T> : IRecipe<T> where T : DishBase
    {
        /// <summary>
        /// Composition of cooked dish
        /// </summary>
        public List<IIngredient> Composition { get; init; }
        
        /// <summary>
        /// Dish cooking sequence
        /// </summary>
        public Queue<IIngredientsHandler> CookingSequence { get; init; }

        /// <summary>
        /// Default constructor
        /// </summary>
        public RecipeBase()
        {
            Composition = new List<IIngredient>();
            CookingSequence = new Queue<IIngredientsHandler>();
        }

        /// <summary>
        /// Cook ingredients
        /// </summary>
        /// <param name="ingredients">List of ingredients to cook</param>
        /// <returns>List of handled ingredients</returns>
        /// <exception cref="UseRecipeWrongIngredientsException">Thrown if ingredients don't contains needed products to cook dish</exception>
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

        /// <summary>
        /// Method to cook dish
        /// </summary>
        /// <param name="ingredients">Ingredients from which dish will cooked</param>
        /// <returns></returns>
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