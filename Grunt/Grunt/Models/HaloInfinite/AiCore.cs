using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class AiCore : Foundation.Core
    {
        public List<AiCoreTheme> Themes { get; set; }
    }
}
