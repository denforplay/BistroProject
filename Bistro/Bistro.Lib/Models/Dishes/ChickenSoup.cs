using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Dishes
{
    public sealed class ChickenSoup : DishBase
    {
        public ChickenSoup(double dishCost, List<IIngredient> ingredients) : base(dishCost, ingredients)
        {
        }
    }
}
