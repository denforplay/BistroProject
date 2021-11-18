using Bistro.Lib.Core.Enums;

namespace Bistro.Lib.Models.StorageConditions
{
    /// <summary>
    /// Represents package condition
    /// </summary>
    public sealed class PackageCondition : IStorageCondition
    {
        private PackageType _packageType;

        /// <summary>
        /// Package condition constructor
        /// </summary>
        /// <param name="packageType">Package type</param>
        public PackageCondition(PackageType packageType)
        {
            _packageType = packageType;
        }
    }
}
