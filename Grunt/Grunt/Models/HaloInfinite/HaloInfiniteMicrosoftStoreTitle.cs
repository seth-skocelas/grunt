namespace Grunt.Models.HaloInfinite
{
    [IsAutomaticallySerializable(IsReady = true)]
    public class HaloInfiniteMicrosoftStoreTitle
    {
        public StoreProductMapping[] ProductMapping { get; set; }
        public string ContainerId { get; set; }
    }
}
