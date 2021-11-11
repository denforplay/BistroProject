using Bistro.Lib.Models.IngridientsHandlers;
using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Ingredients.Sauses
{
    public abstract class SauсeBase : IIngredient
    {
        public List<IStorageCondition> StoreConditions { get; init; }
        public List<IIngredientHandler> IngredientHandlers { get; init; }
        public double Cost { get; set; }
        public double Weight { get; set; }

        public SauсeBase(double cost, double weight)
        {
            Cost = cost;
            Weight = weight;
            StoreConditions = new List<IStorageCondition>()
            {
                new TemperatureCondition(4, 7),
            };

            IngredientHandlers = new List<IIngredientHandler>()
            {
                new AddToDish(0, 0, this),
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
    }
}
