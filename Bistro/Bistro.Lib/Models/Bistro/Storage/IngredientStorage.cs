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
        private StorageConditionsContainer _storageConditions;
        private Dictionary<Type, List<IIngredient>> _ingredients;

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

            _storageConditions = storageConditions;
            _ingredients = ingredients;
        }

        public void Add(Type entity, List<IIngredient> ingredients)
        {
            if (ingredients.TrueForAll(i => i.StoreConditions.Any(s => _storageConditions.GetAll().Any(x => x.Equals(s)))))
            {
                if (_ingredients.TryGetValue(entity, out List<IIngredient> findedIngredients))
                {
                    findedIngredients.AddRange(ingredients);
                }
                else
                {

                    _ingredients.Add(entity, ingredients);
                }
            }
            else
            {
                throw new InapplicableIngredientException();
            }
               
        }

        public void Delete(Type entity, List<IIngredient> ingredient)
        {
            if (_ingredients.TryGetValue(entity, out List<IIngredient> findedIngredients))
            {
                findedIngredients.RemoveList(ingredient);
            }
        }

        public List<IIngredient> GetAll()
        {
            List<IIngredient> allIngredients = new List<IIngredient>();
            foreach (var key in _ingredients.Keys)
            {
                allIngredients.AddRange(GetByKey(key));
            }

            return allIngredients;
        }

        public List<IIngredient> GetByKey(Type key)
        {
            return _ingredients[key];
        }
    }
}