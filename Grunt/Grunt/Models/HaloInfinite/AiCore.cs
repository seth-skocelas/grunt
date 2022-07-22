using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AiCore : Foundation.Core
    {
        public List<AiCoreTheme> Themes { get; set; }
    }
}
