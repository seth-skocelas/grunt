// <copyright file="TierCounterfactuals.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class TierCounterfactuals
    {
        public KillDeathStats Bronze { get; set; }
        public KillDeathStats Silver { get; set; }
        public KillDeathStats Gold { get; set; }
        public KillDeathStats Platinum { get; set; }
        public KillDeathStats Diamond { get; set; }
        public KillDeathStats Onyx { get; set; }
    }
}
