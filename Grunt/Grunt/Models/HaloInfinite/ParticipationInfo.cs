// <copyright file="ParticipationInfo.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System;

namespace OpenSpartan.Grunt.Models.HaloInfinite
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
