using System;
using System.Collections.Generic;
using System.Linq;

namespace Bistro.Lib.Models.Bistro.Capabilities
{
    public sealed class ProductionCapabilities : IProductionCapabilitiesRepository
    {
        public Dictionary<Type, int> Capabilities { get; init; }

        public ProductionCapabilities(Dictionary<Type, int> productionCapabilities)
        {
            Capabilities = productionCapabilities;
        }

        public int GetByKey(Type key)
        {
            return Capabilities[key];
        }

        public void Add(Type capabilityType, int count)
        {
            if (Capabilities.TryGetValue(capabilityType, out int _))
            {
                Capabilities[capabilityType] += count;
            }
            else
            {
                Capabilities.Add(capabilityType, count);
            }
        }

        public void Delete(Type capabilityType, int count)
        {
            if (Capabilities.TryGetValue(capabilityType, out int value))
            {
                if (value - count > 0)
                    Capabilities[capabilityType] -= count;
            }
            else
            {
                Capabilities.Remove(capabilityType);
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is ProductionCapabilities otherCapabilities)
            {
                return Enumerable.SequenceEqual(Capabilities, otherCapabilities.Capabilities);
            }

            return false;
        }

        public override int GetHashCode()
        {
            int hash = 0;

            foreach(var value in Capabilities.Values)
            {
                hash += value.GetHashCode();
            }

            return hash;
        }

        public override string ToString()
        {
            return "Production capabilities";
        }
    }
}
