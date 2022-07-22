using System.Text.Json.Serialization;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class OverrideQueryDefinition
    {
        [JsonPropertyName("schema_version")]
        public int SchemaVersion { get; set; }
        public int Version { get; set; }
        public OverrideQuery[] Overrides { get; set; }
    }
}
