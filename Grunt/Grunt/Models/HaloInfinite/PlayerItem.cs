namespace Grunt.Models.HaloInfinite
{
    public class PlayerItem
    {
        public int Amount { get; set; }
        public string ItemId { get; set; }
        public string ItemPath { get; set; }
        public string ItemType { get; set; }
        public APIFormattedDate FirstAcquiredDate { get;set; }
    }
}
