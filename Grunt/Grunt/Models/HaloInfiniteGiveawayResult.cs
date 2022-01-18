namespace Grunt.Models
{
    public class HaloInifiniteGiveawayResult
    {
        public string GiveawayId { get; set; }
        public string GiveawayPath { get; set; }
        public object[] GrantedCurrencies { get; set; }
        public HaloInfiniteGiveawayGrantedItem[] GrantedItems { get; set; }
    }
}
