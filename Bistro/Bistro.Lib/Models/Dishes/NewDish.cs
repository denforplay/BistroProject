using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Dishes
{
    public sealed class NewDish : DishBase
    {
        private string _dishName;

        public NewDish(double dishCost, List<IIngredient> ingredients, string dishName) : base(dishCost, ingredients)
        {
            _dishName = dishName;
        }

        public override string ToString()
        {
            return $"{_dishName} with cost {Cost}";
        }
    }
}
