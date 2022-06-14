using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    public class OperationRewardTrackSnapshot
    {
        public string ActiveOperationRewardTrackPath { get; set; }
        public List<OperationRewardTrack> OperationRewardTracks { get; set; }
        public string ScheduledOperationRewardTrackPath { get; set; }
    }
}
