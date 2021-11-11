using Bistro.Lib.Models.IngridientsHandlers;
using Bistro.Lib.Models.StorageConditions;
using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Ingredients.Vegetables
{
    public abstract class VegetableBase : IIngredient
    {
        public List<IIngredientHandler> IngredientHandlers { get; init; }
        public double Cost { get; set; }
        public List<IStorageCondition> StoreConditions { get; init; }
        public double Weight { get; set; }

        public VegetableBase(double cost, double weight)
        {
            Cost = cost;
            Weight = weight;
            IngredientHandlers = new List<IIngredientHandler>
            {
                new Slicing(0, 0, this),
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
    }
}
