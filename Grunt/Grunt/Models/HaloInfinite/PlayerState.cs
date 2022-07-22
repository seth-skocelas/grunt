// <copyright file="PlayerState.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class PlayerState
    {
        public RewardTrack[] RewardTracks { get; set; }

        // TODO: Figure out what this type is.
        public object[] ItemBalances { get; set; }
        public CurrencyAmount[] CurrencyBalances { get; set; }
        public bool RefreshNeeded { get; set; }

        // TODO: Figure out what this type is.
        public object[] Boosts { get; set; }
    }

}
