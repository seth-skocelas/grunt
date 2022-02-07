using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    public class CustomizationData
    {
        public SpartanBody SpartanBody { get; set; }
        public Appearance Appearance { get; set; }
        public List<Core> ArmorCores { get; set; }
        public List<Core> WeaponCores { get; set; }
        public List<Core> AiCores { get; set; }
        public List<Core> VehicleCores { get; set; }
    }
}
