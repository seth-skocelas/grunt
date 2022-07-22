namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class AwardedReward
    {
        public Reward Reward { get; set; }
        public string Status { get; set; }
    }

}
