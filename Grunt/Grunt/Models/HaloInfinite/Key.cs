using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    // For more details, refer to: https://datatracker.ietf.org/doc/html/rfc7518
    // Additional context: https://stackoverflow.com/questions/70022898/what-does-e-aqab-mean-in-jwks
    public class Key
    {
        [JsonProperty("kty")]
        public string KeyType { get; set; }
        public string Use { get; set; }
        [JsonProperty("kid")]
        public string KeyId { get; set; }
        [JsonProperty("n")]
        public string Modulus { get; set; }
        [JsonProperty("e")]
        public string Exponent { get; set; }
        [JsonProperty("x5c")]
        public string[] X509CertificateChain { get; set; }
    }

}
