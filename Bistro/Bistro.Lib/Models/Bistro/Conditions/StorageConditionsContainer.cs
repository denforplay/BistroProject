using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.IngredientsHandlers.Base;
using Bistro.Lib.Models.StorageConditions;
using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Bistro.Conditions
{
    public sealed class StorageConditionsContainer : IConditionRepository
    {
        private Dictionary<Type, List<IStorageCondition>> _storageConditions;

        public StorageConditionsContainer(Dictionary<Type, List<IStorageCondition>> storageConditions)
        {
            _storageConditions = storageConditions;
        }

        public void Add(Type entity, List<IStorageCondition> conditionsToAdd)
        {
            if (_storageConditions.TryGetValue(entity, out List<IStorageCondition> conditions))
            {
                conditions.AddRange(conditionsToAdd);
            }
            else
            {
                _storageConditions.Add(entity, conditionsToAdd);
            }
        }

        public void Delete(Type entity, List<IStorageCondition> entityCount)
        {
            if (_storageConditions.TryGetValue(entity, out List<IStorageCondition> conditions))
            {
                conditions.RemoveList(entityCount);
            }
        }

        public List<IStorageCondition> GetByKey(Type key)
        {
            return _storageConditions[key];
        }
    }
}