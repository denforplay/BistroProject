namespace JSONLib.Models
{
    public interface ISerializer
    {
        public void Serialize<T>(T obj) where T : class;
        public T Deserialize<T>() where T : class;
    }
}
