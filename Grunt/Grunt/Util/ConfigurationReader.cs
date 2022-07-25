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
    /// <summary>
    /// Helper class used to read configuration data from disk.
    /// </summary>
    public class ConfigurationReader
    {
        /// <summary>
        /// Reads configuration from a local file and deserializes it into an object.
        /// </summary>
        /// <typeparam name="T">Type of object to deserialize.</typeparam>
        /// <param name="path">Path to the file to read.</param>
        /// <returns>If successful, returns an instance of the object <typeparamref name="T"/>. Otherwise, returns null.</returns>
        public static T ReadConfiguration<T>(string path)
        {
            T? config = default;

            using (StreamReader r = new(path))
            {
                string json = r.ReadToEnd();
                config = JsonSerializer.Deserialize<T>(json);
            }

            return config;
        }
    }
}
