namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class MatchStats
    {
        public string MatchId { get; set; }
        public MatchInfo MatchInfo { get; set; }
        public Team[] Teams { get; set; }
        public Player[] Players { get; set; }
    }
}
