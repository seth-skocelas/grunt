using System;
using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class SkillResult
    {
        public double TeamMmr { get; set; }
        public RankRecap RankRecap { get; set; }
        public StatPerformances StatPerformances { get; set; }
        public int TeamId { get; set; }
        public Dictionary<string, double> TeamMmrs { get; set; }
        //TODO: Investigate that RankedRewards is actually a string. My hunch is that this will be an array.
        public string RankedRewards { get; set; }
        public Counterfactuals Counterfactuals { get; set; }

    }
}
