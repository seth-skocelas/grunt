namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AcademySeries
    {
        public string GameAssetID { get; set; }
        public string MapAssetID { get; set; }
        public bool Available { get; set; }
        public DisplayString Title { get; set; }
        public DisplayString Description { get; set; }
    }
}
