namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class Counterfactuals
    {
        public KillDeathStats SelfCounterfactuals { get; set; }
        public TierCounterfactuals TierCounterfactuals { get; set; }
    }
}
