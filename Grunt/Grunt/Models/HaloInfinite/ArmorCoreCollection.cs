using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class ArmorCoreCollection
    {
        public List<ArmorCore> ArmorCores { get; set; }
    }
}
