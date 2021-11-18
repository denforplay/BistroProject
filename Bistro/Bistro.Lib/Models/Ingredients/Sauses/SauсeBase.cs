using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.Ingredients.Sauses
{
    /// <summary>
    /// Represents sause base
    /// </summary>
    public abstract class SauсeBase : IIngredient
    {
        /// <summary>
        /// Sauce store conditions
        /// </summary>
        public List<IStorageCondition> StoreConditions { get; init; }

        /// <summary>
        /// Sauce ingredient handlers
        /// </summary>
        public List<IIngredientsHandler> IngredientHandlers { get; init; }

        /// <summary>
        /// Sauce cost
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Sauce weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Sauce base constructor
        /// </summary>
        /// <param name="cost">Sauce cost</param>
        /// <param name="weight">Sauce weight</param>
        public SauсeBase(double cost, double weight)
        {
            Cost = cost;
            Weight = weight;
            StoreConditions = new List<IStorageCondition>()
            {
                new TemperatureCondition(4, 7),
            };

            IngredientHandlers = new List<IIngredientsHandler>()
            {
                new AddingToDish(),
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is SauсeBase other)
            {
                return Weight == other.Weight
                       && GetType() == other.GetType();
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1224;
            foreach (var handler in IngredientHandlers)
            {
                hash += hash * 13 + handler.GetHashCode();
            }

            hash += hash * 13 + Cost.GetHashCode();
            hash += hash * 13 + Weight.GetHashCode();
            foreach (var condition in StoreConditions)
            {
                hash += hash * 13 + condition.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with cost {Cost} and weight {Weight}";
        }
    }
}