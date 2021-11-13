using System.IO;
using Newtonsoft.Json;

namespace JSONLib.Models
{
    public class JsonWorker
    {
        private string _filepath;
        private JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
        };

        public JsonWorker(string filepath)
        {
            _filepath = filepath;
        }

        public void Serialize<T>(T objectToSerialize) where T : class
        {
            using (FileStream fs = new FileStream(_filepath, FileMode.Create))
            {
                byte[] data = System.Text.Encoding.Default.GetBytes(JsonConvert.SerializeObject(objectToSerialize, Formatting.Indented, _jsonSettings));
                fs.Write(data, 0, data.Length);
            }
        }

        public T Deserialize<T>() where T : class
        {
            return JsonConvert.DeserializeObject<T>(File.ReadAllText(_filepath), _jsonSettings);
        }
    }
}
