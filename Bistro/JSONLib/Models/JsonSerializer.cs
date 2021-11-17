using System;
using System.IO;
using Newtonsoft.Json;

namespace JSONLib.Models
{
    public class JsonSerializer : ISerializer
    {
        private string _filepath;
        private JsonSerializerSettings _jsonSettings = new JsonSerializerSettings
        {
            TypeNameHandling = TypeNameHandling.Auto,
            ObjectCreationHandling = ObjectCreationHandling.Replace,
        };

        public JsonSerializer(string filepath)
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
            string readed = File.ReadAllText(_filepath);
            T result = JsonConvert.DeserializeObject<T>(readed, _jsonSettings) ?? throw new InvalidOperationException();
            return result;
        }
    }
}
