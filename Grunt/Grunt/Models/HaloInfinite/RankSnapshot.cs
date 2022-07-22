namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class RankSnapshot
    {
        public int Rank { get; set; }
        public RewardContainer FreeRewards { get; set; }
        public RewardContainer PaidRewards { get; set; }
    }
}
