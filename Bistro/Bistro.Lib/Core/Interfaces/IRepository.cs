namespace Bistro.Lib.Core.Interfaces
{
    /// <summary>
    /// Provides repository functionality
    /// </summary>
    /// <typeparam name="TKey">Data key</typeparam>
    /// <typeparam name="TVal">Data value</typeparam>
    public interface IRepository<TKey, TVal>
    {
        /// <summary>
        /// Returns value by key
        /// </summary>
        /// <param name="key">Key</param>
        /// <returns>Returns value by key</returns>
        TVal GetByKey(TKey key);

        /// <summary>
        /// Method adds entity value by entity key
        /// </summary>
        /// <param name="entityKey">Key</param>
        /// <param name="entityValue">Value</param>
        void Add(TKey entityKey, TVal entityValue);

        /// <summary>
        /// Method deletes entity value by entity key
        /// </summary>
        /// <param name="entityKey">Entity key</param>
        /// <param name="entityValue">Entity value</param>
        void Delete(TKey entityKey, TVal entityValue);
    }
}