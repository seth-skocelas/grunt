namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class MatchCsr
    {
        public int Value { get; set; }
        public int MeasurementMatchesRemaining { get; set; }
        public string Tier { get; set; }
        public int TierStart { get; set; }
        public int SubTier { get; set; }
        public string NextTier { get; set; }
        public int NextTierStart { get; set; }
        public int NextSubTier { get; set; }
        public int InitialMeasurementMatches { get; set; }
    }
}
