using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AiCoreCollection
    {
        public List<AiCore> AiCores { get; set; }
    }
}
