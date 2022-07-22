namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class DriverManifest
    {
        public int Version { get; set; }
        public DriverDetails Nvidia { get; set; }
        public DriverDetails AMD { get; set; }
        public DriverDetails Intel { get; set; }
    }
}
