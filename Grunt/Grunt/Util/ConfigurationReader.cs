// <copyright file="ConfigurationReader.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

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
