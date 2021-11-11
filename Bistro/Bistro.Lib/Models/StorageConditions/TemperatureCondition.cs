namespace Bistro.Lib.Models.StorageConditions
{
    public sealed class TemperatureCondition : IStorageCondition
    {
        private double _minTemperature;
        private double _maxTemperature;

        public TemperatureCondition(double minTemperature, double maxTemperature)
        {
            _minTemperature = minTemperature;
            _maxTemperature = maxTemperature;
        }
    }
}
