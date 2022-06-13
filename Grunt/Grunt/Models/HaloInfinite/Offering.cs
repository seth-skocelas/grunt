namespace Grunt.Models.HaloInfinite
{
    public class Offering
    {
        public string OfferingId { get; set; }
        public string OfferingDisplayPath { get; set; }
        public object OfferingExpirationDate { get; set; }
        public PlayerItem[] IncludedItems { get; set; }
        public Price[] Prices { get; set; }
        public object[] IncludedCurrencies { get; set; }
        public object[] IncludedRewardTracks { get; set; }
        public string BoostPath { get; set; }
        public int OperationXp { get; set; }
        public int EventXp { get; set; }
        public object MatchBoosts { get; set; }
    }
}
