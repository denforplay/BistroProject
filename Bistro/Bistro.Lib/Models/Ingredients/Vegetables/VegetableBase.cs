using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.Ingredients.Vegetables
{
    public abstract class VegetableBase : IIngredient
    {
        public List<IIngredientsHandler> IngredientHandlers { get; init; }
        public double Cost { get; set; }
        public List<IStorageCondition> StoreConditions { get; init; }
        public double Weight { get; set; }

        public VegetableBase(double cost, double weight)
        {
            Cost = cost;
            Weight = weight;
            IngredientHandlers = new List<IIngredientsHandler>
            {
                new Slicing(0, 0, null),
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