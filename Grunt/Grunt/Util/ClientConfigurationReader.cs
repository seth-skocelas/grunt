using Newtonsoft.Json;
using Grunt.Models;
using System.IO;

namespace Grunt.Util
{
    public class ClientConfigurationReader
    {
        public ClientConfiguration ReadClientConfiguration(string path = "client.json")
        {
            ClientConfiguration config = null;
            using (StreamReader r = new(path))
            {
                string json = r.ReadToEnd();
                config = JsonConvert.DeserializeObject<ClientConfiguration>(json);
            }
            return config;
        }
    }
}
