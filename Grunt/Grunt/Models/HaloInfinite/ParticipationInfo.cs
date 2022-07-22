using System;

namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ParticipationInfo
    {
        public DateTime FirstJoinedTime { get; set; }
        public object LastLeaveTime { get; set; }
        public bool PresentAtBeginning { get; set; }
        public bool JoinedInProgress { get; set; }
        public bool LeftInProgress { get; set; }
        public bool PresentAtCompletion { get; set; }
        public string TimePlayed { get; set; }
        public object ConfirmedParticipation { get; set; }
    }
}
