using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    public class AICores
    {
        [JsonProperty("AICores")]
        public AICore[] Cores { get; set; }
    }

}
