namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Counterfactuals
    {
        public KillDeathStats SelfCounterfactuals { get; set; }
        public TierCounterfactuals TierCounterfactuals { get; set; }
    }
}
