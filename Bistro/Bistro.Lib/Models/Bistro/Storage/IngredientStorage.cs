using System;
using System.Collections.Generic;
using System.Linq;
using Bistro.Lib.Core.Exceptions;
using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.Bistro.Conditions;
using Bistro.Lib.Models.Ingredients;

namespace Bistro.Lib.Models.Bistro.Storage
{
    public sealed class IngredientStorage : IIngredientRepository
    {
        public IConditionRepository StorageConditions { get; init; }
        public Dictionary<Type, List<IIngredient>> Ingredients { get; init; }

        public IngredientStorage()
        {
            StorageConditions = new StorageConditionsContainer();
            Ingredients = new Dictionary<Type, List<IIngredient>>();
        }

        public IngredientStorage(Dictionary<Type, List<IIngredient>> ingredients, StorageConditionsContainer storageConditions)
        {
            if (storageConditions is null)
            {
                throw new ArgumentNullException(nameof(storageConditions));
            }

            if (ingredients is null || ingredients.Count == 0)
            {
                throw new ArgumentNullException(nameof(ingredients));
            }

            StorageConditions = storageConditions;
            Ingredients = ingredients;
        }

        public void Add(Type entity, List<IIngredient> ingredients)
        {
            if (ingredients.TrueForAll(i => i.StoreConditions.Any(s => StorageConditions.GetAll().Any(x => x.Equals(s)))))
            {
                if (Ingredients.TryGetValue(entity, out List<IIngredient> findedIngredients))
                {
                    findedIngredients.AddRange(ingredients);
                }
                else
                {

                    Ingredients.Add(entity, ingredients);
                }
            }
            else
            {
                throw new InapplicableIngredientException();
            }
               
        }

        public void Delete(Type entity, List<IIngredient> ingredient)
        {
            if (Ingredients.TryGetValue(entity, out List<IIngredient> findedIngredients))
            {
                findedIngredients.RemoveList(ingredient);
            }
        }

        public List<IIngredient> GetAll()
        {
            List<IIngredient> allIngredients = new List<IIngredient>();
            foreach (var key in Ingredients.Keys)
            {
                allIngredients.AddRange(GetByKey(key));
            }

            return allIngredients;
        }

        public List<IIngredient> GetByKey(Type key)
        {
            return Ingredients[key];
        }
    }
}