
using Newtonsoft.Json;

namespace Grunt.Models
{
    public class ClientConfiguration
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }

        [JsonProperty("client_secret")]
        public string ClientSecret { get; set; }

        [JsonProperty("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}
