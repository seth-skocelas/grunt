// <copyright file="RewardTrackMetadata.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class RewardTrackMetadata
    {
        public string TrackId { get; set; }
        public int XpPerRank { get; set; }
        public RankSnapshot[] Ranks { get; set; }
        public DisplayString Name { get; set; }
        public DisplayString Description { get; set; }
        public int OperationNumber { get; set; }
        public DisplayString DateRange { get; set; }
        public bool IsRitual { get; set; }
        public string SummaryImagePath { get; set; }
        public int WeekNumber { get; set; }
        public string BackgroundImagePath { get; set; }
    }
}
