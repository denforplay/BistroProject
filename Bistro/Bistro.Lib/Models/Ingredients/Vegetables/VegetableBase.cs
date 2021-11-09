using Bistro.Lib.Models.IngridientsHandlers;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Ingredients.Vegetables
{
    public abstract class VegetableBase : IIngredient
    {
        public List<IIngredientHandler> IngredientHandlers { get; init; }
        public double Cost { get; set; }

        public VegetableBase(double cost)
        {
            Cost = cost;
            IngredientHandlers = new List<IIngredientHandler>
            {
                new Slicing(0, 0, this),
            };
        }
    }
}
