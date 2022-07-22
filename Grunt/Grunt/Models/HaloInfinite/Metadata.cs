namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Metadata
    {
        public Manufacturer[] Manufacturers { get; set; }
        public Currency[] Currencies { get; set; }
    }
}
