using System.Text.Json.Serialization;

namespace Grunt.Models
{
    public class ClientConfiguration
    {
        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("redirect_url")]
        public string RedirectUrl { get; set; }
    }
}
