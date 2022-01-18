namespace Grunt.Models.HaloInfinite
{
    public class VehicleCore
    {
        public string CoreId { get; set; }
        public string CorePath { get; set; }
        public VehicleCoreTheme[] Themes { get; set; }
        public string CoreType { get; set; }
    }
}
