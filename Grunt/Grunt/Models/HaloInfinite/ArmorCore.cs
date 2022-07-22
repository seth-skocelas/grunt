using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ArmorCore : Foundation.Core
    {
        public List<ArmorCoreTheme> Themes { get; set; }
    }
}
