namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class CustomMapData
    {
        public int NumOfObjectsOnMap { get; set; }
        public int TagLevelId { get; set; }
        public bool IsBaked { get; set; }
        public bool HasNodeGraph { get; set; }
    }
}
