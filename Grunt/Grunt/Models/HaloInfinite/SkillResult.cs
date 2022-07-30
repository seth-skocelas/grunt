using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    public class SkillResult
    {
        public double TeamMmr { get; set; }
        public RankRecap RankRecap { get; set; }
        public StatPerformances StatPerformances { get; set; }
        public int TeamId { get; set; }
        public Dictionary<String, Double> TeamMmrs { get; set; }
        public RankedRewards RankedRewards { get; set; }
        public Counterfactuals Counterfactuals { get; set; }

    }
}
