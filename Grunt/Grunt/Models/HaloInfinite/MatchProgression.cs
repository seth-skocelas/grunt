namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class MatchProgression
    {
        public string ClearanceId { get; set; }
        public string RewardId { get; set; }
        public ChallengeProgressState[] ChallengeProgressState { get; set; }
    }
}
