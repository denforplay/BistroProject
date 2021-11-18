namespace Bistro.Lib.Models.Ingredients.Meat
{
    /// <summary>
    /// Represents chicken meat
    /// </summary>
    public sealed class Chicken : MeatBase
    {
        /// <summary>
        /// Chicken meat constructor
        /// </summary>
        /// <param name="cost">Chicken meat cost</param>
        /// <param name="weight">Chicken meat weight</param>
        public Chicken(double cost, double weight) : base(cost, weight)
        {
        }
    }
}
