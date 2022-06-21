using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    public class OverrideSettings
    {
        [JsonProperty("spec_control_async_compute")]
        public bool SpecControlAsyncCompute { get; set; }
    }


}
