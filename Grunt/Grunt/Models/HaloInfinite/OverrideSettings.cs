using System.Text.Json.Serialization;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class OverrideSettings
    {
        [JsonPropertyName("spec_control_async_compute")]
        public bool SpecControlAsyncCompute { get; set; }
    }
}
