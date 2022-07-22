// <copyright file="Key.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Text.Json.Serialization;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    // For more details, refer to: https://datatracker.ietf.org/doc/html/rfc7518
    // Additional context: https://stackoverflow.com/questions/70022898/what-does-e-aqab-mean-in-jwks
    public class Key
    {
        [JsonPropertyName("kty")]
        public string KeyType { get; set; }
        public string Use { get; set; }
        [JsonPropertyName("kid")]
        public string KeyId { get; set; }
        [JsonPropertyName("n")]
        public string Modulus { get; set; }
        [JsonPropertyName("e")]
        public string Exponent { get; set; }
        [JsonPropertyName("x5c")]
        public string[] X509CertificateChain { get; set; }
    }

}
