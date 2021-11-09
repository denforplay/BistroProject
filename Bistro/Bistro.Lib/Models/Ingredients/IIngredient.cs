using Bistro.Lib.Models.IngridientsHandlers;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Ingredients
{
    public interface IIngredient
    {
        List<IIngredientHandler> IngredientHandlers { get; init; }
        double Cost { get; set; }
    }
}
