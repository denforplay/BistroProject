using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Dishes
{
    public sealed class Salad : DishBase
    {
        public Salad(double cost, List<IIngredient> ingredients) : base(cost, ingredients)
        {
        }
    }
}
