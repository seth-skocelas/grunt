// <copyright file="Query.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Query
    {
        public string Key { get; set; }
        public string Op { get; set; }

        /// <summary>
        /// Value used for the query. Can be a string or an array of strings, and needs to be unfurled directly by the developer at runtime.
        /// </summary>
        public object Value { get; set; }
    }


}
