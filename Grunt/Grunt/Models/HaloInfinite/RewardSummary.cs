// <copyright file="RewardSummary.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

using System.Collections.Generic;

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class RewardSummary
    {
        public List<RewardTrack> UpdatedRewardTracks { get; set; }
        public List<AwardedReward> AwardedRewards { get; set; }
        public List<GrantedCurrency> GrantedCurrencies { get; set; }
        public List<PlayerItem> GrantedItems { get; set; }
    }

}
