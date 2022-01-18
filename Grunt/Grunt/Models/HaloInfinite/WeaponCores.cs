using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    public class WeaponCores
    {
        [JsonProperty("WeaponCores")]
        public WeaponCore[] Cores { get; set; }
    }
}
