namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class RewardSnapshot
    {
        public RewardSummary RewardsSummary { get; set; }
        public PlayerState PlayerState { get; set; }
    }
}
