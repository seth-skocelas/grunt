using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ArmorCore : Foundation.Core
    {
        public List<ArmorCoreTheme> Themes { get; set; }
    }
}
