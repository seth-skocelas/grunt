// <copyright file="Stats.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Stats
    {
        public CoreStats CoreStats { get; set; }
        public object BombStats { get; set; }
        public object CaptureTheFlagStats { get; set; }
        public EliminationStats EliminationStats { get; set; }
        public object ExtractionStats { get; set; }
        public object InfectionStats { get; set; }
        public object OddballStats { get; set; }
        public object ZonesStats { get; set; }
        public object StockpileStats { get; set; }
    }
}
