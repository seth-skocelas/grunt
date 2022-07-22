namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Metadata
    {
        public Manufacturer[] Manufacturers { get; set; }
        public Currency[] Currencies { get; set; }
    }
}
