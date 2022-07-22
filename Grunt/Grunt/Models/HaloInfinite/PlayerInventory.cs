namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class PlayerInventory
    {
        public PlayerItem[] Items { get; set; }
    }
}
