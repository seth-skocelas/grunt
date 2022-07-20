using System.Text.Json.Serialization;

namespace Grunt.Models.HaloInfinite
{
    public class OverrideQueryDefinition
    {
        [JsonPropertyName("schema_version")]
        public int SchemaVersion { get; set; }
        public int Version { get; set; }
        public OverrideQuery[] Overrides { get; set; }
    }
}
