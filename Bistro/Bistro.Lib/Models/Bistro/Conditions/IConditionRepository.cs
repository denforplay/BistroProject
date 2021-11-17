using Bistro.Lib.Core.Interfaces;
using Bistro.Lib.Models.StorageConditions;
using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Bistro.Conditions
{
    public interface IConditionRepository : IRepository<Type, List<IStorageCondition>>
    {
        public List<IStorageCondition> GetAll();
    }
}