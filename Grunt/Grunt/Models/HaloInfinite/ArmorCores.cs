using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    public class ArmorCores
    {
        [JsonProperty("ArmorCores")]
        public ArmorCore[] Cores { get; set; }
    }
}
