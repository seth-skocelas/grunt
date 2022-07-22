// <copyright file="RewardTrack.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class RewardTrack
    {
        public string RewardTrackPath { get; set; }
        public string TrackType { get; set; }
        public RewardTrackProgress CurrentProgress { get; set; }
        public RewardTrackProgress PreviousProgress { get; set; }
        public bool IsOwned { get; set; }
        public object BaseXp { get; set; }
        public object BoostXp { get; set; }
    }

}
