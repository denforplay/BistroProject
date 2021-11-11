using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Models.Ingredients;
using System.Linq;

namespace Bistro.Lib.Models.IngridientsHandlers
{
    public sealed class AddToDish : IIngredientHandler
    {
        private readonly IIngredient _ingredient;

        public double Cost { get; init; }
        public double Duration { get; init; }

        public AddToDish(double cost, double duration, IIngredient ingredient)
        {
            Cost = cost;
            Duration = duration;
            _ingredient = ingredient;
        }

        public void Handle()
        {
            if (_ingredient.IngredientHandlers.Any(x => x.GetType() == GetType()))
            {
                _ingredient.Cost += Cost;
            }
            else
            {
                throw new InapplicableHandlerException(this, _ingredient);
            }
        }
    }
}
