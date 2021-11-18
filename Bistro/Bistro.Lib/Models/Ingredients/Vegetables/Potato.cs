namespace Bistro.Lib.Models.Ingredients.Vegetables
{
    /// <summary>
    /// Represents potato
    /// </summary>
    public sealed class Potato : VegetableBase
    {
        /// <summary>
        /// Potato constructor
        /// </summary>
        /// <param name="cost">Potato cost</param>
        /// <param name="weight">Potato weight</param>
        public Potato(double cost, double weight) : base(cost, weight)
        {
        }
    }
}
