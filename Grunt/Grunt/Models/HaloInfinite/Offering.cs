// <copyright file="Offering.cs" company="Den Delimarsky">
// Developed by Den Delimarsky.
// Den Delimarsky licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.
// The underlying API powering Grunt is managed by 343 Industries and Microsoft. This wrapper is not endorsed by 343 Industries or Microsoft.
// </copyright>

namespace OpenSpartan.Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class Offering
    {
        public string OfferingId { get; set; }
        public string OfferingDisplayPath { get; set; }
        public APIFormattedDate OfferingExpirationDate { get; set; }
        public PlayerItem[] IncludedItems { get; set; }
        public Price[] Prices { get; set; }
        public CurrencyAmount[] IncludedCurrencies { get; set; }
        public string[] IncludedRewardTracks { get; set; }
        public string BoostPath { get; set; }
        public int OperationXp { get; set; }
        public int EventXp { get; set; }
        
        // TODO: Figure out what exactly this is.
        public object MatchBoosts { get; set; }
    }
}
