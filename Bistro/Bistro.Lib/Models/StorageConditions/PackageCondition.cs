using Bistro.Lib.Core.Enums;

namespace Bistro.Lib.Models.StorageConditions
{
    public sealed class PackageCondition : IStorageCondition
    {
        private PackageType _packageType;

        public PackageCondition(PackageType packageType)
        {
            _packageType = packageType;
        }
    }
}
