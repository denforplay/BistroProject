namespace Bistro.Lib.Models.Ingredients.MilkProducts
{
    /// <summary>
    /// Represents milk
    /// </summary>
    public sealed class Milk : MilkProductBase
    {
        /// <summary>
        /// Milk constructor
        /// </summary>
        /// <param name="cost">Milk cost</param>
        /// <param name="weight">Milk weight</param>
        public Milk(double cost, double weight) : base(cost, weight)
        {
        }
    }
}
