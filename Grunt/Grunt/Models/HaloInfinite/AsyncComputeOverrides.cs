using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AsyncComputeOverrides
    {
        public Dictionary<string, bool> Nvidia { get; set; }
        public Dictionary<string, bool> AMD { get; set; }
        public Dictionary<string, bool> Intel { get; set; }
    }
}
