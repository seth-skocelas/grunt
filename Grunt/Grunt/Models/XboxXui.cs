// <copyright file="XboxXui.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Text.Json.Serialization;

namespace OpenSpartan.Grunt.Models
{
    public class XboxXui
    {
        [JsonPropertyName("uhs")]
        public string Uhs { get; set; }

        [JsonPropertyName("gtg")]
        public string Gtg { get; set; }

        [JsonPropertyName("xid")]
        public string Xid { get; set; }

        [JsonPropertyName("agg")]
        public string Agg { get; set; }

        [JsonPropertyName("usr")]
        public string Usr { get; set; }

        [JsonPropertyName("utr")]
        public string Utr { get; set; }

        [JsonPropertyName("prv")]
        public string Prv { get; set; }
    }
}
