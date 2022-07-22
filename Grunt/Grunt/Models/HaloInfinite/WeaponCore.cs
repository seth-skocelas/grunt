using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class WeaponCore : Foundation.Core
    {
        public List<WeaponCoreTheme> Themes { get; set; }
    }
}
