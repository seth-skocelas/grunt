using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class ActiveBoostsContainer
    {
        public List<ActiveBoost> Boosts { get; set; }
    }
}
