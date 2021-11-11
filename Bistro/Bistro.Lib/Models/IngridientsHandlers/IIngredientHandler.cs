using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.IngridientsHandlers
{
    public interface IIngredientHandler
    {
        IIngredient Ingredient { get; set; }
        double Cost { get; init; }
        double Duration { get; init; }
        void Handle();
    }
}
