using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class VehicleCore : Models.HaloInfinite.Foundation.Core
    {
        public List<VehicleCoreTheme> Themes { get; set; }
    }
}
