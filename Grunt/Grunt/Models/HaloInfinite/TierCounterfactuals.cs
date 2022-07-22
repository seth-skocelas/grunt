namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class TierCounterfactuals
    {
        public KillDeathStats Bronze { get; set; }
        public KillDeathStats Silver { get; set; }
        public KillDeathStats Gold { get; set; }
        public KillDeathStats Platinum { get; set; }
        public KillDeathStats Diamond { get; set; }
        public KillDeathStats Onyx { get; set; }
    }
}
