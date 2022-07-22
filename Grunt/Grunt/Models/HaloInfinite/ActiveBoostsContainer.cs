using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ActiveBoostsContainer
    {
        public List<ActiveBoost> Boosts { get; set; }
    }
}
