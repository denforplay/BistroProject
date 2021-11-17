using Bistro.Lib.Models.Bistro.Capabilities;
using Bistro.Lib.Models.Bistro.Storage;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Recipes.Base;
using Bistro.Lib.Models.WorkingStuff;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Bistro
{
    public sealed class Kitchen
    {
        public Kitchen (Chef chef, IIngredientRepository ingredientStorage, IProductionCapabilitiesRepository productionCapabilities)
        {
            Chef = chef;
            IngredientStorage = ingredientStorage;
            ProductionCapabilities = productionCapabilities;
        }

        public IIngredientRepository IngredientStorage { get; init; }
        public Chef Chef { get; init; }
        public IProductionCapabilitiesRepository ProductionCapabilities { get; init; }

        public DishBase CookDish(IRecipe<DishBase> recipe)
        {
            DishBase cookedDish = Chef.Cook(recipe, IngredientStorage.GetAll());

            foreach (var ingredient in recipe.Composition)
            {
                IngredientStorage.Delete(ingredient.GetType().BaseType, new List<IIngredient> { ingredient });
            }

            return cookedDish;
        }
    }
}
