// <copyright file="SkillResult.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System;
using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class SkillResult
    {
        public double TeamMmr { get; set; }
        public RankRecap RankRecap { get; set; }
        public StatPerformances StatPerformances { get; set; }
        public int TeamId { get; set; }
        public Dictionary<string, double> TeamMmrs { get; set; }
        public RankedRewards RankedRewards { get; set; }
        public Counterfactuals Counterfactuals { get; set; }

    }
}
