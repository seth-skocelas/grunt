using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class OperationRewardTrackSnapshot
    {
        public string ActiveOperationRewardTrackPath { get; set; }
        public List<RewardTrackMetadata> OperationRewardTracks { get; set; }
        public string ScheduledOperationRewardTrackPath { get; set; }
    }
}
