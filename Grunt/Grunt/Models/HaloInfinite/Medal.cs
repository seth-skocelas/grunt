namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Medal
    {
        public long NameId { get; set; }
        public int Count { get; set; }
        public int TotalPersonalScoreAwarded { get; set; }
    }
}
