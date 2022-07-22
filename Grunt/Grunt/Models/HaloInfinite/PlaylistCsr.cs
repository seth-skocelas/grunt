// <copyright file="PlaylistCsr.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlaylistCsr
    {
        public int Value { get; set; }
        public int MeasurementMatchesRemaining { get; set; }
        public string Tier { get; set; }
        public int TierStart { get; set; }
        public int SubTier { get; set; }
        public string NextTier { get; set; }
        public int NextTierStart { get; set; }
        public int NextSubTier { get; set; }
        public int InitialMeasurementMatches { get; set; }
    }
}
