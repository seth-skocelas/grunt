using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class WeaponCoreCollection
    {
        public List<WeaponCore> WeaponCores { get; set; }
    }
}
