namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Reward
    {
        public int EventXp { get; set; }
        public int OperationXp { get; set; }

        // TODO: Figure out what this type is.
        public object[] InventoryItems { get; set; }
        public string TrackingId { get; set; }

        // TODO: Figure out what this type is.
        public object[] Currencies { get; set; }

        // I am making an assumption here that still needs to be validated that this is truly RewardTrack and not
        // something completely different.
        public RewardTrack[] RewardTrackProgression { get; set; }
    }

}
