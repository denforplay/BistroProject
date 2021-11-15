namespace Bistro.Lib.Core.Interfaces
{
    public interface IRepository<TKey, TVal>
    {
        TVal GetByKey(TKey key);
        void Add(TKey entity, TVal entityCount);
        void Delete(TKey entity, TVal entityCount);
    }
}