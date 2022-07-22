using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class OperationRewardTrackSnapshot
    {
        public string ActiveOperationRewardTrackPath { get; set; }
        public List<RewardTrackMetadata> OperationRewardTracks { get; set; }
        public string ScheduledOperationRewardTrackPath { get; set; }
    }
}
