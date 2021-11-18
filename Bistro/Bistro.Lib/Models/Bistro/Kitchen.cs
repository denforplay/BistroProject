using Bistro.Lib.Models.Bistro.Capabilities;
using Bistro.Lib.Models.Bistro.Storage;
using Bistro.Lib.Models.Dishes;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Recipes.Base;
using Bistro.Lib.Models.WorkingStuff;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Bistro
{
    /// <summary>
    /// Represents kitchen
    /// </summary>
    public sealed class Kitchen
    {
        /// <summary>
        /// Kitchen constructor
        /// </summary>
        /// <param name="chef">Chef</param>
        /// <param name="ingredientStorage">Ingredient storage</param>
        /// <param name="productionCapabilities">Production capabilities</param>
        public Kitchen (Chef chef, IIngredientRepository ingredientStorage, IProductionCapabilitiesRepository productionCapabilities)
        {
            Chef = chef;
            IngredientStorage = ingredientStorage;
            ProductionCapabilities = productionCapabilities;
        }
        
        /// <summary>
        /// Ingredient repository
        /// </summary>
        public IIngredientRepository IngredientStorage { get; init; }

        /// <summary>
        /// Chef chef
        /// </summary>
        public Chef Chef { get; init; }

        /// <summary>
        /// Production capabilities
        /// </summary>
        public IProductionCapabilitiesRepository ProductionCapabilities { get; init; }

        /// <summary>
        /// Cook dish by recipe method
        /// </summary>
        /// <param name="recipe">Recipe</param>
        /// <returns>Cooked dish</returns>
        public ProductBase CookDish(IRecipe<ProductBase> recipe)
        {
            ProductBase cookedDish = Chef.Cook(recipe, IngredientStorage.GetAll());

            foreach (var ingredient in recipe.Composition)
            {
                IngredientStorage.Delete(ingredient.GetType().BaseType, new List<IIngredient> { ingredient });
            }

            return cookedDish;
        }
    }
}
