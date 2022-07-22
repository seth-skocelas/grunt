using System.Text.Json.Serialization;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class OverrideSettings
    {
        [JsonPropertyName("spec_control_async_compute")]
        public bool SpecControlAsyncCompute { get; set; }
    }
}
