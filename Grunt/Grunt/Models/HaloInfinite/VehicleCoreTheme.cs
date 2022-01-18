namespace Grunt.Models.HaloInfinite
{
    public class VehicleCoreTheme
    {
        public SpartanDate FirstModifiedDateUtc { get; set; }
        public SpartanDate LastModifiedDateUtc { get; set; }
        public bool IsEquipped { get; set; }
        public bool IsDefault { get; set; }
        public string ThemePath { get; set; }
        public string CoatingPath { get; set; }
        public string HornPath { get; set; }
        public string VehicleFxPath { get; set; }
        public string VehicleCharmPath { get; set; }
        public Emblem[] Emblems { get; set; }
        public string AlternateGeometryRegionPath { get; set; }
    }
}
