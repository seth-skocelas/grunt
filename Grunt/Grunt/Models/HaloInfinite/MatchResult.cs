namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class MatchResult
    {
        public string MatchId { get; set; }
        public MatchInfo MatchInfo { get; set; }
        public int LastTeamId { get; set; }
        public int Outcome { get; set; }
        public int Rank { get; set; }
        public bool PresentAtEndOfMatch { get; set; }
    }

}
