using System.Text.Json.Serialization;

namespace Grunt.Models
{
    public class GruntConfiguration
    {
        [JsonPropertyName("clearance_token")]
        public string ClearanceToken { get; set; }
    }
}
