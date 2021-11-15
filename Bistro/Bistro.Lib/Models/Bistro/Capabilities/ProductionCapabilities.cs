using System;
using System.Collections.Generic;

namespace Bistro.Lib.Models.Bistro.Capabilities
{
    public sealed class ProductionCapabilities : IProductionCapabilitiesRepository
    {
        private readonly Dictionary<Type, int> _productionCapabilities;
        public ProductionCapabilities(Dictionary<Type, int> productionCapabilities)
        {
            _productionCapabilities = productionCapabilities;
        }

        public int GetByKey(Type key)
        {
            return _productionCapabilities[key];
        }

        public void Add(Type capabilityType, int count)
        {
            if (_productionCapabilities.TryGetValue(capabilityType, out int _))
            {
                _productionCapabilities[capabilityType] += count;
            }
            else
            {
                _productionCapabilities.Add(capabilityType, count);
            }
        }

        public void Delete(Type capabilityType, int count)
        {
            if (_productionCapabilities.TryGetValue(capabilityType, out int value))
            {
                if (value - count > 0)
                    _productionCapabilities[capabilityType] -= count;
            }
            else
            {
                _productionCapabilities.Remove(capabilityType);
            }
        }

    }
}
