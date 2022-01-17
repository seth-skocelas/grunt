using Newtonsoft.Json;

namespace Grunt.Models
{
    public class XboxXui
    {
        [JsonProperty("uhs")]
        public string Uhs { get; set; }

        [JsonProperty("gtg")]
        public string Gtg { get; set; }

        [JsonProperty("xid")]
        public string Xid { get; set; }

        [JsonProperty("agg")]
        public string Agg { get; set; }

        [JsonProperty("usr")]
        public string Usr { get; set; }

        [JsonProperty("utr")]
        public string Utr { get; set; }

        [JsonProperty("prv")]
        public string Prv { get; set; }
    }
}
