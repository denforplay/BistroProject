using System;
using Bistro.Lib.Models.Ingredients;
using Bistro.Lib.Models.Ingredients.Meat;
using Bistro.Lib.Models.Ingredients.Sauses;
using Bistro.Lib.Models.Ingredients.Vegetables;
using Bistro.Lib.Models.Recipes;
using Bistro.Lib.Models.WorkingStuff;
using System.Collections.Generic;
using Bistro.Lib.Models.IngredientsHandlers;
using Bistro.Lib.Models.IngredientsHandlers.Base;
using Bistro.Lib.Models.Recipes.SaladRecipes;
using Xunit;

namespace Bistro.Tests.ModelsTests
{
    public sealed class ChefTests
    {
        [Fact]
        public void TestCookChief_NullIngredients_ThrowArgumentNullException()
        {
            Chef chef = new Chef();
            Assert.Throws<ArgumentNullException>(() => chef.Cook(new VegetableSaladRecipe(), null)); 
        }
        
        [Fact]
        public void TestCookChief_EmptyIngredients_ThrowArgumentNullException()
        {
            Chef chef = new Chef();
            Assert.Throws<ArgumentNullException>(() => chef.Cook(new VegetableSaladRecipe(), new List<IIngredient>())); 
        }
        
        [Fact]
        public void TestCookUsingRecipe_AllDataValid_ReturnTrue()
        {
            Chef chef = new Chef();
            List<IIngredient> ingredients = new List<IIngredient>()
            {
                new Cucumber(5, 5),
                new Ketchup(5, 5),
                new Tomato(5, 5)
            };

            Assert.Equal(32, chef.Cook(new VegetableSaladRecipe(), ingredients).Cost);
        }

        [Fact]
        public void CreateNewRecipeTest_NullComposition_ThrowsArgumentNullException()
        {
            Chef chef = new Chef();
            Assert.Throws<ArgumentNullException>(() => chef.CreateNewRecipe(null,
                new Queue<IIngredientsHandler>(new List<IIngredientsHandler>
                {
                    new Slicing(5, 5, new List<IIngredient>
                    {
                        new Tomato(5, 5)
                    }),
                }), "Cutted tomate"));
        }
        
        [Fact]
        public void CreateNewRecipeTest_NullCookingSequence_ThrowsArgumentNullException()
        {
            Chef chef = new Chef();
            Assert.Throws<ArgumentNullException>(() => chef.CreateNewRecipe(new List<IIngredient>
                {
                    new Tomato(5, 5)
                },
                null, "Cutted tomate"));
        }
        
        [Fact]
        public void CreateNewRecipeTest_NullDishName_ThrowsArgumentNullException()
        {
            Chef chef = new Chef();
            Assert.Throws<ArgumentNullException>(() => chef.CreateNewRecipe(new List<IIngredient>
            {
                new Chicken(5, 5),
                new Tomato(5, 5)
            },new Queue<IIngredientsHandler>(new List<IIngredientsHandler>
            {
                new Slicing(5, 5, new List<IIngredient>
                {
                    new Tomato(5, 5)
                }),
            }), null));
        }

        [Fact]
        public void CreateNewRecipeTest_ValidData_ReturnsTrue()
        {
            Chef chef = new Chef();
         
            List<IIngredient> composition = new List<IIngredient>
            {
                new Cucumber(5, 5),
                new Tomato(5, 5),
                new Chicken(10, 5)
            };

            Queue<IIngredientsHandler> cookingSequence = new Queue<IIngredientsHandler>();
            cookingSequence.Enqueue(new Baking(10, 10, new List<IIngredient>{composition[2]}));
            cookingSequence.Enqueue(new Slicing(5, 5, new List<IIngredient>{composition[0]}));
            cookingSequence.Enqueue(new Slicing(5, 5, new List<IIngredient>{composition[1]}));

            var newRecipe = chef.CreateNewRecipe(composition, cookingSequence, "Chicken with vegetables");
            Assert.True(newRecipe is NewRecipe);
            var dish = chef.Cook(newRecipe, composition);
        }
    }
}
