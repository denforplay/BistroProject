using Bistro.Lib.Core.Enums;
using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.Ingredients.Meat
{
    /// <summary>
    /// Represents meat base
    /// </summary>
    public abstract class MeatBase : IIngredient
    {
        /// <summary>
        /// Meet store conditions
        /// </summary>
        public List<IStorageCondition> StoreConditions { get; init; }

        /// <summary>
        /// Meat hanglers
        /// </summary>
        public List<IIngredientsHandler> IngredientHandlers { get; init; }

        /// <summary>
        /// Meat cost
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Meat weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Meat base constructor
        /// </summary>
        /// <param name="cost">Meat cost</param>
        /// <param name="weight">Meat weight</param>
        public MeatBase(double cost, double weight)
        {
            Cost = cost;
            Weight = weight;
            StoreConditions = new List<IStorageCondition>()
            {
                new TemperatureCondition(0, 5),
                new MoistureCondition(85, 90),
                new PackageCondition(PackageType.ClosedContainer)
            };

            IngredientHandlers = new List<IIngredientsHandler>()
            {
                new Slicing(),
                new Baking(),
                new AddingToDish()
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is MeatBase other)
            {
                return Weight == other.Weight
                    && GetType() == other.GetType();
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1222;
            foreach (var handler in IngredientHandlers)
            {
                hash += hash * 12 + handler.GetHashCode();
            }

            hash += hash * 12 + Cost.GetHashCode();
            hash += hash * 12 + Weight.GetHashCode();
            foreach (var condition in StoreConditions)
            {
                hash += hash * 12 + condition.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with price: {Cost} and weight: {Weight}";
        }
    }
}
