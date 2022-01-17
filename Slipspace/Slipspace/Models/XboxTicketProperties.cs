using Newtonsoft.Json;

namespace Slipspace.Models
{
    public class XboxTicketProperties
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string AuthMethod { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SiteName { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string RpsTicket { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string[] UserTokens { get; set; }
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public string SandboxId { get; set; }
    }
}
