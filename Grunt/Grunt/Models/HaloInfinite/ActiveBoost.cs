// <copyright file="ActiveBoost.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class ActiveBoost
    {
        public APIFormattedDate ExpirationDate { get; set; }
        public string State { get; set; }
        public string BoostPath { get; set; }
        public float EffectiveMultiplier { get; set; }
        public int Matches { get; set; }
    }
}
