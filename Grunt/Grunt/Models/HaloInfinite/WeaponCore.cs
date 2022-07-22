using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class WeaponCore : Foundation.Core
    {
        public List<WeaponCoreTheme> Themes { get; set; }
    }
}
