namespace Bistro.Lib.Models.Ingredients.Vegetables
{
    /// <summary>
    /// Represents tomato vegetable
    /// </summary>
    public sealed class Tomato : VegetableBase
    {
        /// <summary>
        /// Tomato constructor
        /// </summary>
        /// <param name="cost">Tomato cost</param>
        /// <param name="weight">Tomato weight</param>
        public Tomato(double cost, double weight) : base(cost, weight)
        {
        }
    }
}
