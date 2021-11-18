namespace Bistro.Lib.Models.Ingredients.Sauses
{
    /// <summary>
    /// Represents ketchup
    /// </summary>
    public sealed class Ketchup : SauсeBase
    {
        /// <summary>
        /// Ketchup constructor
        /// </summary>
        /// <param name="cost">Ketchup cost</param>
        /// <param name="weight">Ketchup weight</param>
        public Ketchup(double cost, double weight) : base(cost, weight)
        {
        }
    }
}
