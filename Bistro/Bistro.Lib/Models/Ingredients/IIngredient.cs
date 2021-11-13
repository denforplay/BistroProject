using Bistro.Lib.Models.IngridientsHandlers;
using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Ingredients
{
    public interface IIngredient
    {
        List<IStorageCondition> StoreConditions { get; init; }
        List<IIngredientsHandler> IngredientHandlers { get; init; }
        double Cost { get; set; }
        double Weight { get; set; }
    }
}
