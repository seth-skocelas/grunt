using Newtonsoft.Json;

namespace Grunt.Models.HaloInfinite
{
    public class VehicleCores
    {
        [JsonProperty("VehicleCores")]
        public VehicleCore[] Cores { get; set; }
    }
}
