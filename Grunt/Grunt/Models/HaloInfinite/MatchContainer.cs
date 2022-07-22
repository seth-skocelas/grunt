namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class MatchContainer
    {
        public int Start { get; set; }
        public int Count { get; set; }
        public int ResultCount { get; set; }
        public MatchResult[] Results { get; set; }
        public MatchLinks Links { get; set; }
    }
}
