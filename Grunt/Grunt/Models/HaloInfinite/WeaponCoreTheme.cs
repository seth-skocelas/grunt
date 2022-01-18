namespace Grunt.Models.HaloInfinite
{
    public class WeaponCoreTheme
    {
        public SpartanDate FirstModifiedDateUtc { get; set; }
        public SpartanDate LastModifiedDateUtc { get; set; }
        public bool IsEquipped { get; set; }
        public bool IsDefault { get; set; }
        public string ThemePath { get; set; }
        public string CoatingPath { get; set; }
        public Emblem[] Emblems { get; set; }
        public string DeathFxPath { get; set; }
        public string AmmoCounterColorPath { get; set; }
        public string StatTrackerPath { get; set; }
        public string WeaponCharmPath { get; set; }
        public string AlternateGeometryRegionPath { get; set; }
    }
}
