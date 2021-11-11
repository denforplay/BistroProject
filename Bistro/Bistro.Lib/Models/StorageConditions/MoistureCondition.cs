namespace Bistro.Lib.Models.StorageConditions
{
    public sealed class MoistureCondition : IStorageCondition
    {
        private double _minMoisture;
        private double _maxMoisture;

        public MoistureCondition(double minMoisture, double maxMoisture)
        {
            _minMoisture = minMoisture;
            _maxMoisture = maxMoisture;
        }
    }
}
