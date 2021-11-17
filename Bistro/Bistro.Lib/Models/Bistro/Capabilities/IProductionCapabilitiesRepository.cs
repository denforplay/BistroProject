using System;
using Bistro.Lib.Core.Interfaces;

namespace Bistro.Lib.Models.Bistro.Capabilities
{
    /// <summary>
    /// Provides production capability data storage functionality
    /// </summary>
    public interface IProductionCapabilitiesRepository : IRepository<Type, int>
    {
    }
}