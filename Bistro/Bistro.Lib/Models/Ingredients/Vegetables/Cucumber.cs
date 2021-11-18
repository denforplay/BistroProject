namespace Bistro.Lib.Models.Ingredients.Vegetables
{
    /// <summary>
    /// Represents cucumber
    /// </summary>
    public sealed class Cucumber : VegetableBase
    {
        /// <summary>
        /// Cucumber constructor
        /// </summary>
        /// <param name="cost">Cucumber cost</param>
        /// <param name="weight">Cucumber weight</param>
        public Cucumber(double cost, double weight) : base(cost, weight)
        {
        }
    }
}
