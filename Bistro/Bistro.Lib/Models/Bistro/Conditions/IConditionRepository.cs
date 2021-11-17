using Bistro.Lib.Core.Interfaces;
using Bistro.Lib.Models.StorageConditions;
using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Bistro.Conditions
{
    /// <summary>
    /// Provides condition data storage functionality
    /// </summary>
    public interface IConditionRepository : IRepository<Type, List<IStorageCondition>>
    {
        /// <summary>
        /// Method returns all storage conditions
        /// </summary>
        /// <returns>All storage conditions</returns>
        public List<IStorageCondition> GetAll();
    }
}