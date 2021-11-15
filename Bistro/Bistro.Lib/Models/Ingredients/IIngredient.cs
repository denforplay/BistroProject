using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;

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
