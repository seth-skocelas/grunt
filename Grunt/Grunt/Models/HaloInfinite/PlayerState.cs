namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerState
    {
        public RewardTrack[] RewardTracks { get; set; }

        // TODO: Figure out what this type is.
        public object[] ItemBalances { get; set; }
        public CurrencyAmount[] CurrencyBalances { get; set; }
        public bool RefreshNeeded { get; set; }

        // TODO: Figure out what this type is.
        public object[] Boosts { get; set; }
    }

}
