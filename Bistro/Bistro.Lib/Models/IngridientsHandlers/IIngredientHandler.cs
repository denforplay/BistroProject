namespace Bistro.Lib.Models.IngridientsHandlers
{
    public interface IIngredientHandler
    {
        double Cost { get; init; }
        double Duration { get; init; }
        void Handle();
    }
}
