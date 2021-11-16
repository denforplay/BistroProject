using Bistro.Lib.Models.Bistro.Capabilities;
using Bistro.Lib.Models.Bistro.Storage;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Recipes.Base;
using Bistro.Lib.Models.WorkingStuff;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Bistro
{
    public class Kitchen
    {
        private Chef _chef;
        private IProductionCapabilitiesRepository _productionCapabilities;

        public Kitchen (Chef chef, IIngredientRepository ingredientStorage, IProductionCapabilitiesRepository productionCapabilities)
        {
            _chef = chef;
            IngredientStorage = ingredientStorage;
            _productionCapabilities = productionCapabilities;
        }

        public IIngredientRepository IngredientStorage { get; set; }

        public DishBase CookDish(IRecipe<DishBase> recipe)
        {
            return _chef.Cook(recipe, IngredientStorage.GetAll());
        }
    }
}
