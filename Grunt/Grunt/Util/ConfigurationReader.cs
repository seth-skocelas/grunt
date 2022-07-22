using System.IO;
using System.Text.Json;

namespace OpenSpartan.Grunt.Util
{
    public class ConfigurationReader
    {
        public T ReadConfiguration<T>(string path)
        {
            T config = default(T);
            using (StreamReader r = new(path))
            {
                string json = r.ReadToEnd();
                config = JsonSerializer.Deserialize<T>(json);
            }
            return config;
        }
    }
}
