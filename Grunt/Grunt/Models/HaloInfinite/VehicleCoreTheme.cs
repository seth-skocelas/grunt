using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    public class VehicleCoreTheme : Models.HaloInfinite.Foundation.Theme
    {
        public string CoatingPath { get; set; }
        public string HornPath { get; set; }
        public string VehicleFxPath { get; set; }
        public string VehicleCharmPath { get; set; }
        public List<Emblem> Emblems { get; set; }
        public string AlternateGeometryRegionPath { get; set; }
    }
}
