using Newtonsoft.Json;

namespace Grunt.Models
{
    public class GruntConfiguration
    {
        [JsonProperty("clearance_token")]
        public string ClearanceToken { get; set; }
    }
}
