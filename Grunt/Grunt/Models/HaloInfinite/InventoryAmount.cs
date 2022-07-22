namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable]
    public class InventoryAmount
    {
        public string InventoryItemPath { get; set; }
        public int Amount { get; set; }
        public string Type { get; set; }
    }
}
