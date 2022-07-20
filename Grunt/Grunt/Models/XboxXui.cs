using System.Text.Json.Serialization;

namespace Grunt.Models
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
