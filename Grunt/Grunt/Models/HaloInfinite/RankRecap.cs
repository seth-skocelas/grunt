namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class RankRecap
    {
        public MatchCsr PreMatchCsr { get; set; }
        public MatchCsr PostMatchCsr { get; set; }
    }
}
