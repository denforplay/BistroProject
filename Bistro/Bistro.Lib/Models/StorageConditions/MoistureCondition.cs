namespace Bistro.Lib.Models.StorageConditions
{
    /// <summary>
    /// Represents moisture condition
    /// </summary>
    public sealed class MoistureCondition : IStorageCondition
    {
        private double _minMoisture;
        private double _maxMoisture;

        /// <summary>
        /// Moisture condition constructor
        /// </summary>
        /// <param name="minMoisture">Minimal moisture limit</param>
        /// <param name="maxMoisture">Maximal moisture limit</param>
        public MoistureCondition(double minMoisture, double maxMoisture)
        {
            _minMoisture = minMoisture;
            _maxMoisture = maxMoisture;
        }
    }
}
