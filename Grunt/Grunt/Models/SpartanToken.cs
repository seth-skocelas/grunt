// <copyright file="SpartanToken.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Text.Json.Serialization;

namespace OpenSpartan.Grunt.Models
{

    public class SpartanToken
    {
        [JsonPropertyName("SpartanToken")]
        public string Token { get; set; }
        public APIFormattedDate ExpiresUtc { get; set; }
        public string TokenDuration { get; set; }
    }
}
