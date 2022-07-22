using System.Text.Json.Serialization;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class OverrideQueryDefinition
    {
        [JsonPropertyName("schema_version")]
        public int SchemaVersion { get; set; }
        public int Version { get; set; }
        public OverrideQuery[] Overrides { get; set; }
    }
}
