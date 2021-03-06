using Bistro.Lib.Core.Extensions;
using Bistro.Lib.Models.IngredientsHandlers.Base;
using Bistro.Lib.Models.StorageConditions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Models.Bistro.Conditions
{
    /// <summary>
    /// Represents storage condition data storage container
    /// </summary>
    public sealed class StorageConditionsContainer : IConditionRepository
    {
        /// <summary>
        /// Storage conditions
        /// </summary>
        public Dictionary<Type, List<IStorageCondition>> StorageConditions { get; init; }

        /// <summary>
        /// Storage condtions container constructor
        /// </summary>
        public StorageConditionsContainer()
        {
            StorageConditions = new Dictionary<Type, List<IStorageCondition>>();
        }

        /// <summary>
        /// Storage conditions container
        /// </summary>
        /// <param name="storageConditions">Storage conditions</param>
        /// <exception cref="ArgumentNullException">Throws if storage conditions is null</exception>
        public StorageConditionsContainer(Dictionary<Type, List<IStorageCondition>> storageConditions)
        {
            if (storageConditions is null)
            {
                throw new ArgumentNullException(nameof(storageConditions));
            }

            StorageConditions = storageConditions;
        }

        public void Add(Type entity, List<IStorageCondition> conditionsToAdd)
        {
            if (StorageConditions.TryGetValue(entity, out List<IStorageCondition> conditions))
            {
                conditions.AddRange(conditionsToAdd);
            }
            else
            {
                StorageConditions.Add(entity, conditionsToAdd);
            }
        }

        public void Delete(Type entity, List<IStorageCondition> entityCount)
        {
            if (StorageConditions.TryGetValue(entity, out List<IStorageCondition> conditions))
            {
                conditions.RemoveList(entityCount);
            }
        }

        public List<IStorageCondition> GetAll()
        {
            List<IStorageCondition> storageConditions = new List<IStorageCondition>();
            foreach (var value in StorageConditions.Values)
            {
                storageConditions.AddRange(value);
            }

            return storageConditions;
        }

        public List<IStorageCondition> GetByKey(Type key)
        {
            return StorageConditions[key];
        }
    }
}