namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Medal
    {
        public long NameId { get; set; }
        public int Count { get; set; }
        public int TotalPersonalScoreAwarded { get; set; }
    }
}
