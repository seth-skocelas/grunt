namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlayerMatchCount
    {
        public int CustomMatchesPlayedCount { get; set; }
        public int MatchesPlayedCount { get; set; }
        public int MatchmadeMatchesPlayedCount { get; set; }
        public int LocalMatchesPlayedCount { get; set; }
    }

}
