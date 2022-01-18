using Newtonsoft.Json;
using System.IO;

namespace Grunt.Util
{
    public class ConfigurationReader
    {
        public T ReadConfiguration<T>(string path)
        {
            T config = default(T);
            using (StreamReader r = new(path))
            {
                string json = r.ReadToEnd();
                config = JsonConvert.DeserializeObject<T>(json);
            }
            return config;
        }
    }
}
