using System.Collections.Generic;
using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.IngredientsHandlers.Base
{
    public interface IIngredientsHandler
    {
        List<IIngredient> Ingredients { get; set; }
        double Cost { get; init; }
        double Duration { get; init; }
        void Handle();
    }
}
