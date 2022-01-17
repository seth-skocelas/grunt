
using Newtonsoft.Json;

namespace Slipspace.Models
{
    public class ClientConfiguration
    {
        [JsonProperty("client_id")]
        public string ClientId { get; set; }
    }
}
