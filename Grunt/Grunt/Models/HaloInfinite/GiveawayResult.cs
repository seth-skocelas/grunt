namespace Grunt.Models.HaloInfinite
{
    public class GiveawayResult
    {
        public string GiveawayId { get; set; }
        public string GiveawayPath { get; set; }
        public object[] GrantedCurrencies { get; set; }
        public GiveawayGrantedItem[] GrantedItems { get; set; }
    }
}
