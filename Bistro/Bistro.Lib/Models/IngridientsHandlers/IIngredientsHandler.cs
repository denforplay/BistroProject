using Bistro.Lib.Models.Ingredients;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Bistro.Lib.Models.IngridientsHandlers
{
    public interface IIngredientsHandler
    {
        List<IIngredient> Ingredients { get; set; }
        double Cost { get; init; }
        double Duration { get; init; }
        void Handle();
    }
}
