namespace Bistro.Lib.Models.StorageConditions
{
    /// <summary>
    /// Represents temperature condition
    /// </summary>
    public sealed class TemperatureCondition : IStorageCondition
    {
        private double _minTemperature;
        private double _maxTemperature;

        /// <summary>
        /// Temperature condition
        /// </summary>
        /// <param name="minTemperature">Minimal temperature limit</param>
        /// <param name="maxTemperature">Maximal temperature limit</param>
        public TemperatureCondition(double minTemperature, double maxTemperature)
        {
            _minTemperature = minTemperature;
            _maxTemperature = maxTemperature;
        }
    }
}
