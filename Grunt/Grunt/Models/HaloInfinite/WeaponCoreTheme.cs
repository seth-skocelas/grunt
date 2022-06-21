using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    public class WeaponCoreTheme : Models.HaloInfinite.Foundation.Theme
    {
        public string CoatingPath { get; set; }
        public List<Emblem> Emblems { get; set; }
        public Emblem BigEmblem { get; set; }
        public string DeathFxPath { get; set; }
        public string AmmoCounterColorPath { get; set; }
        public string StatTrackerPath { get; set; }
        public string WeaponCharmPath { get; set; }
        public string AlternateGeometryRegionPath { get; set; }
        public string AmmoCounterPath { get; set; }
    }
}
