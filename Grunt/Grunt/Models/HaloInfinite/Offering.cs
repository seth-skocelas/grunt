namespace Grunt.Models.HaloInfinite
{
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
