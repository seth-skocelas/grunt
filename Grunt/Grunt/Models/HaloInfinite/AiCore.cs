using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AiCore : Foundation.Core
    {
        public List<AiCoreTheme> Themes { get; set; }
    }
}
