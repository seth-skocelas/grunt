namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class TestDrill
    {
        public string GameVariant { get; set; }
        public string MapVariant { get; set; }
        public string GameplayGUID { get; set; }
        public bool Available { get; set; }
        public DisplayString Description { get; set; }
    }

}
