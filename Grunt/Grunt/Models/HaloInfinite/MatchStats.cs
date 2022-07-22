namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class MatchStats
    {
        public string MatchId { get; set; }
        public MatchInfo MatchInfo { get; set; }
        public Team[] Teams { get; set; }
        public Player[] Players { get; set; }
    }
}
