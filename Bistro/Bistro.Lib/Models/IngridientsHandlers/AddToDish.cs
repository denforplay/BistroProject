using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;
using System.Linq;

namespace Bistro.Lib.Models.IngridientsHandlers
{
    public sealed class AddToDish : IIngredientHandler
    {
        public double Cost { get; init; }
        public double Duration { get; init; }
        public IIngredient Ingredient { get; set; }

        public AddToDish(double cost, double duration, IIngredient ingredient)
        {
            Cost = cost;
            Duration = duration;
            Ingredient = ingredient;
        }

        public void Handle()
        {
            if (Ingredient.IngredientHandlers.Any(x => x.GetType() == GetType()))
            {
                Ingredient.Cost += Cost;
            }
            else
            {
                throw new InapplicableHandlerException(this, Ingredient);
            }
        }
    }
}
