using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.Ingredients.Vegetables
{
    /// <summary>
    /// Represents vegetable base
    /// </summary>
    public abstract class VegetableBase : IIngredient
    {
        /// <summary>
        /// Ingrdient handlers
        /// </summary>
        public List<IIngredientsHandler> IngredientHandlers { get; init; }

        /// <summary>
        /// Ingredient cost
        /// </summary>
        public double Cost { get; set; }

        /// <summary>
        /// Store conditions
        /// </summary>
        public List<IStorageCondition> StoreConditions { get; init; }

        /// <summary>
        /// Ingredient weight
        /// </summary>
        public double Weight { get; set; }

        /// <summary>
        /// Vegetable base constructor
        /// </summary>
        /// <param name="cost">Vegetable cost</param>
        /// <param name="weight">Vegetable weight</param>
        public VegetableBase(double cost, double weight)
        {
            Cost = cost;
            Weight = weight;
            IngredientHandlers = new List<IIngredientsHandler>
            {
                new Slicing(),
                new AddingToDish(),
            };

            StoreConditions = new List<IStorageCondition>
            {
                new TemperatureCondition(0, 1),
                new MoistureCondition(80, 95)
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is VegetableBase other)
            {
                return GetType() == other.GetType()
                    && Weight == other.Weight;
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 1424;
            foreach (var handler in IngredientHandlers)
            {
                hash += hash * 19 + handler.GetHashCode();
            }

            hash += hash * 19 + Cost.GetHashCode();
            hash += hash * 19 + Weight.GetHashCode();
            foreach (var condition in StoreConditions)
            {
                hash += hash * 19 + condition.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with cost {Cost} and weight {Weight}";
        }
    }
}