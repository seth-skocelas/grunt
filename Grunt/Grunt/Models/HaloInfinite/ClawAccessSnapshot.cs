using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ClawAccessSnapshot
    {
        public List<long> FullClawXuids { get; set; }
        public List<long> ConsumerClawXuids { get; set; }
    }

}
