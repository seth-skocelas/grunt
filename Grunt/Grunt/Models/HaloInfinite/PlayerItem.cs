namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlayerItem
    {
        public int Amount { get; set; }
        public string ItemId { get; set; }
        public string ItemPath { get; set; }
        public string ItemType { get; set; }
        public string CoreType { get; set; }
        public string Source { get; set; }
        public APIFormattedDate FirstAcquiredDate { get;set; }
    }
}
