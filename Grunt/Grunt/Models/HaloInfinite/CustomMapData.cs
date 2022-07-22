namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class CustomMapData
    {
        public int NumOfObjectsOnMap { get; set; }
        public int TagLevelId { get; set; }
        public bool IsBaked { get; set; }
        public bool HasNodeGraph { get; set; }
    }
}
