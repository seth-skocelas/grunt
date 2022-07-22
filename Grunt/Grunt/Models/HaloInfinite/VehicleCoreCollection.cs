using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class VehicleCoreCollection
    {
        public List<VehicleCore> VehicleCores { get; set; }
    }
}
