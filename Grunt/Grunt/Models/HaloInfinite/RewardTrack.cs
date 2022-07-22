namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class RewardTrack
    {
        public string RewardTrackPath { get; set; }
        public string TrackType { get; set; }
        public RewardTrackProgress CurrentProgress { get; set; }
        public RewardTrackProgress PreviousProgress { get; set; }
        public bool IsOwned { get; set; }
        public object BaseXp { get; set; }
        public object BoostXp { get; set; }
    }

}
