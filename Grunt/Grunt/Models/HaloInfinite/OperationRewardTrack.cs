namespace Grunt.Models.HaloInfinite
{
    public class OperationRewardTrack
    {
        public string RewardTrackPath { get; set; }
        public string TrackType { get; set; }
        public RewardTrackProgress CurrentProgress { get; set; }
        public object PreviousProgress { get; set; }
        public bool IsOwned { get; set; }
        public object BaseXp { get; set; }
        public object BoostXp { get; set; }
    }

}
