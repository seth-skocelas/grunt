using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ActiveBoostsContainer
    {
        public List<ActiveBoost> Boosts { get; set; }
    }
}
