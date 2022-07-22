using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class ClawAccessSnapshot
    {
        public List<long> FullClawXuids { get; set; }
        public List<long> ConsumerClawXuids { get; set; }
    }

}
