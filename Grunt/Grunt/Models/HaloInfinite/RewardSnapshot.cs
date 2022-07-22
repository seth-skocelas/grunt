namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class RewardSnapshot
    {
        public RewardSummary RewardsSummary { get; set; }
        public PlayerState PlayerState { get; set; }
    }
}
