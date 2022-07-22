namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class RewardContainer
    {
        public InventoryAmount[] InventoryRewards { get; set; }
        public CurrencyAmount[] CurrencyRewards { get; set; }
    }
}
