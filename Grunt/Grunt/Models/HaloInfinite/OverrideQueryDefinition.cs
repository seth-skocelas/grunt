using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    public class OverrideQueryDefinition
    {
        [JsonProperty("schema_version")]
        public int SchemaVersion { get; set; }
        public int Version { get; set; }
        public OverrideQuery[] Overrides { get; set; }
    }
}
