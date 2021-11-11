using Bistro.Lib.Models.IngridientsHandlers;
using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Ingredients.Meat
{
    public abstract class MeatBase : IIngredient
    {
        public List<IStorageCondition> StoreConditions { get; init; }
        public List<IIngredientHandler> IngredientHandlers { get; init; }
        public double Cost { get; set; }
        public double Weight { get; set; }
        public MeatBase(double cost, double weight)
        {
            Cost = cost;
            Weight = weight;
            StoreConditions = new List<IStorageCondition>()
            {
                new TemperatureCondition(0, 5),
                new MoistureCondition(85, 90)
            };

            IngredientHandlers = new List<IIngredientHandler>()
            {
                new Slicing(5, 5, this),
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
            hash += Weight.GetHashCode();
            hash += Cost.GetHashCode();
            hash += StoreConditions.GetHashCode();
            hash += IngredientHandlers.GetHashCode();
            return hash;
        }

        public override string ToString()
        {
            return $"{GetType().Name} with price: {Cost} and weight: {Weight}";
        }
    }
}
