using System.Collections.Generic;

namespace Grunt.Models.HaloInfinite
{
    public class RewardSummary
    {
        public List<RewardTrack> UpdatedRewardTracks { get; set; }
        public List<AwardedReward> AwardedRewards { get; set; }
        public List<GrantedCurrency> GrantedCurrencies { get; set; }

        // TODO: Figure out what this type is.
        public object[] GrantedItems { get; set; }
    }

}
