using Bistro.Lib.Models.StorageConditions;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;

namespace Bistro.Lib.Models.Ingredients.MilkProducts
{
    public abstract class MilkProductBase : IIngredient
    {
        public List<IStorageCondition> StoreConditions { get; init; }
        public List<IIngredientsHandler> IngredientHandlers { get; init; }
        public double Cost { get; set; }
        public double Weight { get; set; }

        public MilkProductBase(double cost, double weight)
        {
            Cost = cost;
            Weight = weight;
            StoreConditions = new List<IStorageCondition>()
            {
                new TemperatureCondition(0, 6),
            };

            IngredientHandlers = new List<IIngredientsHandler>()
            {
                new AddingToDish(0, 0, null),
            };
        }

        public override bool Equals(object obj)
        {
            if (obj is MilkProductBase other)
            {
                return Weight == other.Weight
                    && GetType() == other.GetType();
            }

            return false;
        }
    }
}
