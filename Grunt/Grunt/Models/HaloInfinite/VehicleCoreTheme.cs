using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class VehicleCoreTheme : Foundation.Theme
    {
        public string CoatingPath { get; set; }
        public string HornPath { get; set; }
        public string VehicleFxPath { get; set; }
        public string VehicleCharmPath { get; set; }
        public List<Emblem> Emblems { get; set; }
        public string AlternateGeometryRegionPath { get; set; }
    }
}
